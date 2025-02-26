using Azure.Messaging.ServiceBus;


const string _connectionString = "Endpoint=sb://127.0.0.1;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
const string _queueName = "queue.1";

const int numOfMessages = 3;

var client = new ServiceBusClient(_connectionString);

var sender = client.CreateSender(_queueName);

using var messageBatch = await sender.CreateMessageBatchAsync();

for (var i = 1; i <= numOfMessages; i++)
{
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
    {
        throw new Exception($"The message {i} is too large to fit in the batch.");
    }
}

try
{
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"A batch of {numOfMessages} messages has been published.");
}
finally
{
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
