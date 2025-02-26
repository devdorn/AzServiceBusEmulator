using Azure.Messaging.ServiceBus;

const string _connectionString = "Endpoint=sb://localhost:5672;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
const string queueName = "queue.1";

var client = new ServiceBusClient(_connectionString);

var serviceBusReceiverOptions = new ServiceBusReceiverOptions
{
    ReceiveMode = ServiceBusReceiveMode.PeekLock
};

var receiver = client.CreateReceiver(queueName, serviceBusReceiverOptions);

try
{
    Console.WriteLine("Receiving messages...");

    while (true)
    {
        var message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));

        if (message != null)
        {
            Console.WriteLine($"Received message: {message.Body}");
            await receiver.CompleteMessageAsync(message);
        }
        else
        {
            Console.WriteLine("No messages received.");
            break;
        }
    }
}
finally
{
    await receiver.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
