using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "test-group2",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    ClientId = "consumer3"
};
using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("test-topic");
try
{
    while (true)
    {
        var message = consumer.Consume();
        Console.WriteLine($"Received message: {message.Message.Value}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}