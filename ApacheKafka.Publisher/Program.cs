using ApacheKafka.Shared;
using Confluent.Kafka;

Person person = new Person();

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

var topic = "ByteOverflow.UserCreated";

while (true)
{
    var message = new Message<Null, string> { Value = $"Hello, Kafka! {DateTime.Now}" };

    producer.Produce(topic, message, deliveryReport => {
        Console.WriteLine(deliveryReport.Message.Value);
    });

    await Task.Delay(1000);
}
 