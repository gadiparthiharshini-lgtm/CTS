using KafkaChat;

// =====================================================================
//  WebApi Hands-on 6 - Kafka streaming chat application
//  A single console app that runs as either a producer (publisher) or a
//  consumer (client), both talking to the same Kafka topic "chat".
//
//  Usage:
//    dotnet run -- producer [name]     # type messages, publish to Kafka
//    dotnet run -- consumer [group]    # read messages from Kafka
//
//  Run one consumer (or several, in different terminals) and one producer
//  to see messages stream across command-prompt "clients".
// =====================================================================

const string bootstrapServers = "localhost:9092";
const string topic = "chat";

var mode = args.Length > 0 ? args[0].ToLowerInvariant() : "consumer";

switch (mode)
{
    case "producer":
        var name = args.Length > 1 ? args[1] : "user";
        await ChatProducer.RunAsync(bootstrapServers, topic, name);
        break;

    case "consumer":
        var group = args.Length > 1 ? args[1] : "chat-consumers";
        ChatConsumer.Run(bootstrapServers, topic, group);
        break;

    default:
        Console.WriteLine("Unknown mode. Use 'producer' or 'consumer'.");
        Console.WriteLine("  dotnet run -- producer Alice");
        Console.WriteLine("  dotnet run -- consumer");
        break;
}
