using Confluent.Kafka;

namespace KafkaChat;

// Subscribes to the chat topic and prints every message to the command prompt.
// Run this in one or more terminals to act as chat "client" applications.
public static class ChatConsumer
{
    public static void Run(string bootstrapServers, string topic, string groupId)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe(topic);

        Console.WriteLine($"[Consumer] Listening on '{topic}' (group '{groupId}'). Ctrl+C to stop.\n");

        // Graceful shutdown on Ctrl+C.
        using var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
        };

        try
        {
            while (true)
            {
                var message = consumer.Consume(cts.Token);
                Console.WriteLine($"{message.Message.Key}: {message.Message.Value}");
            }
        }
        catch (OperationCanceledException)
        {
            // Ctrl+C requested - fall through to clean up.
        }
        finally
        {
            consumer.Close();
            Console.WriteLine("[Consumer] Stopped.");
        }
    }
}
