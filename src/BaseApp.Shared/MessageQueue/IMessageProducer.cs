namespace BaseApp.Shared.MessageQueue;

internal interface IMessageProducer
{
    Task SendMessageAsync(string queueName, string message);
}
