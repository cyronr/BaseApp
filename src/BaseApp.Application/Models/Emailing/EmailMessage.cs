using BaseApp.Shared.Emailing;

namespace BaseApp.Application.Models.Emailing;

public class EmailMessage : IEmail
{
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    public IEnumerable<IAddress>? To { get; set; }
    public IEnumerable<IAddress>? CC { get; set; }
    public IEnumerable<IAddress>? BCC { get; set; }
}
