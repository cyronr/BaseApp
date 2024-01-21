namespace BaseApp.Shared.Emailing;

public interface IEmail
{
    public IEnumerable<IAddress>? To { get; set; }
    public IEnumerable<IAddress>? CC { get; set; }
    public IEnumerable<IAddress>? BCC { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}