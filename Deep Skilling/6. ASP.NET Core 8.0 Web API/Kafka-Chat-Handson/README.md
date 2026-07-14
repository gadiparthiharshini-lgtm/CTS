# Kafka Chat — WebApi Hands-on 6

A **Kafka streaming chat application** in **C# (.NET 8)** using the
`Confluent.Kafka` client. Messages published by a **producer** are streamed
through a Kafka **topic** and consumed by one or more **consumers** running in
separate command prompts — exactly the demo described in WebApi_Handson 6.

## Kafka concepts (outline)

- **Topic** — a named stream of messages (`chat` here). Producers write to it, consumers read from it.
- **Partition** — a topic is split into ordered partitions for scale/parallelism.
- **Broker** — a Kafka server that stores partitions; a cluster is a set of brokers.
- **Zookeeper** — coordinates the cluster (broker metadata, leader election). *(Newer Kafka can run KRaft mode without Zookeeper.)*
- **Producer / Consumer** — .NET apps that publish / subscribe via the `Confluent.Kafka` plug-in.

## Project structure

```
KafkaChat/
├── KafkaChat.csproj    # net8.0 console app + Confluent.Kafka
├── Program.cs          # mode dispatch: producer | consumer
├── ChatProducer.cs     # publishes typed messages to the topic
└── ChatConsumer.cs     # subscribes and prints messages
```

## Prerequisites — install & start Kafka (Windows)

Download Apache Kafka, then from the Kafka install folder:

```bat
:: 1. Start Zookeeper
bin\windows\zookeeper-server-start.bat config\zookeeper.properties

:: 2. Start the Kafka broker (new terminal)
bin\windows\kafka-server-start.bat config\server.properties

:: 3. Create the "chat" topic (new terminal)
bin\windows\kafka-topics.bat --create --topic chat --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```

The app connects to the default broker address `localhost:9092`.

> Guides:
> - https://www.c-sharpcorner.com/article/apache-kafka-net-application/
> - https://www.c-sharpcorner.com/article/step-by-step-installation-and-configuration-guide-of-apache-kafka-on-windows-ope/

## How to run

Open **two or more terminals** in the `KafkaChat` folder.

```bash
# Terminal A - a chat client (consumer)
dotnet run -- consumer

# Terminal B - another chat client (consumer)
dotnet run -- consumer

# Terminal C - publish messages (producer)
dotnet run -- producer Alice
```

Type in the producer terminal; every line appears in all consumer terminals:

```
Alice: hello everyone
Alice: kafka is streaming this message
```

Type `exit` in the producer to stop it; press `Ctrl+C` to stop a consumer.

## Key takeaways
- Kafka decouples senders and receivers through a durable, partitioned **topic**.
- A **producer** writes keyed messages; **consumers** in a group read them independently.
- The `Confluent.Kafka` plug-in makes .NET producers/consumers a few lines of code.
- Running multiple consumers demonstrates fan-out to several "client" applications.
