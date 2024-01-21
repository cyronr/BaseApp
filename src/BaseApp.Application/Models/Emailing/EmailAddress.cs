using BaseApp.Shared.Emailing;

namespace BaseApp.Application.Models.Emailing;

internal class EmailAddress : IAddress
{
    public string Address { get; set; } = null!;
    public string? Name { get; set; }

    public EmailAddress(string address, string? name = default) => 
        (Address, Name) = (address, name);
}
