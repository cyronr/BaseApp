using BaseApp.Shared.Emailing;

namespace BaseApp.Application.Services.Interfaces;

public interface IEmailerService
{
    Task Send(IEmail email);
}
