using Confluent.Kafka;

namespace KafkaChat;

// Publishes chat messages typed at the console to the Kafka topic.
// The sender's name is used as the message key; the text is the value.
public static class ChatProducer
{
    public static async Task RunAsync(string bootstrapServers, string topic, string name)
    {
        var config = new ProducerConfig { BootstrapServers = bootstrapServers };

        using var producer = new ProducerBuilder<string, string>(config).Build();

        Console.WriteLine($"[Producer] Connected as '{name}'. Type messages and press Enter.");
        Console.WriteLine("[Producer] Type 'exit' to quit.\n");

        while (true)
        {
            var text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text) || text.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            try
            {
                var result = await producer.ProduceAsync(
                    topic,
                    new Message<string, string> { Key = name, Value = text });

                Console.WriteLine($"  -> delivered to {result.TopicPartitionOffset}");
            }
            catch (ProduceException<string, string> ex)
            {
                Console.WriteLine($"  !! delivery failed: {ex.Error.Reason}");
            }
        }

        // Wait up to 10s for any in-flight messages to be delivered.
        producer.Flush(TimeSpan.FromSeconds(10));
        Console.WriteLine("[Producer] Stopped.");
    }
}
