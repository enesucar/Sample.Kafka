using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;

Consumer();

Console.WriteLine("hello");

Console.ReadLine();

static async void Consumer()
{
    var config = new ConsumerConfig
    {
        BootstrapServers = "localhost:9092",
        GroupId = "test-group1",
        AutoOffsetReset = AutoOffsetReset.Earliest,
        ClientId = "consumer1",
        AllowAutoCreateTopics = true,
    };
    var consumer = new ConsumerBuilder<Null, string>(config).Build();
    consumer.Subscribe("ByteOverflow.UserCreated");
    try
    {
        while (true)
        {
            await Console.Out.WriteLineAsync("I'm working..");
            var message = consumer.Consume();
            if (message.IsPartitionEOF)
            {
                Console.WriteLine($"Received message: {message.Message.Value}");

            }
            Console.WriteLine($"Received message: {message.Message.Value}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}