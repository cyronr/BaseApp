namespace BaseApp.Shared.MessageQueue;

public interface IMessageConsumer
{
    Task StartConsumingAsync(string queueName);
}
