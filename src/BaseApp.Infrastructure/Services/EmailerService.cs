using BaseApp.Application.Models.Emailing;
using BaseApp.Application.Services.Interfaces;
using BaseApp.Shared.Emailing;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Smtp;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace BaseApp.Infrastructure.Services;

internal class EmailerService : IEmailerService
{

    #region DI
    private readonly ILogger<EmailerService> _logger;

    public EmailerService(ILogger<EmailerService> logger)
    {
        _logger = logger;

        Email.DefaultSender = new SmtpSender(() => new SmtpClient("172.17.0.4")
        {
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Port = 25
        });
    }
    #endregion

    public async Task Send(IEmail email)
    {
        try
        {
            SendResponse response = await Email
                .From("remigiusz@cyron.com")
                .To(email.To?.Select(x => new Address(x.Address)))
                .Subject(email.Subject)
                .Body(email.Body, true)
                .SendAsync();
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}
