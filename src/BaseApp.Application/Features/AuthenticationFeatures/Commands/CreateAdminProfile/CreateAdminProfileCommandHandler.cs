using BaseApp.Application.Features.AuthenticationFeatures.Common;
using BaseApp.Application.Models.Emailing;
using BaseApp.Application.Persistence;
using BaseApp.Application.Persistence.Repositories;
using BaseApp.Application.Services.Interfaces;
using BaseApp.Domain.Entities.ProfileEntities;
using BaseApp.Domain.EntitiesParams.UpdateParams;
using BaseApp.Domain.Exceptions;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BaseApp.Application.Features.AuthenticationFeatures.Commands.CreateAdminProfile;

internal class CreateAdminProfileCommandHandler(ILogger<CreateAdminProfileCommandHandler> logger,
    IUnitOfWork unitOfWork,
    IPasswordService passwordService,
    IJwtTokenService jwtTokenService,
    IEmailerService emailerService
    ) : IRequestHandler<CreateAdminProfileCommand, AuthenticationResult>
{
    #region DI
    private readonly ILogger<CreateAdminProfileCommandHandler> _logger = logger;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;
    private readonly IEmailerService _emailerService = emailerService;
    #endregion

    public async Task<AuthenticationResult> Handle(CreateAdminProfileCommand request, CancellationToken cancellationToken)
    {
        IProfileRepository profileRepository = _unitOfWork.GetRepository<Profile, IProfileRepository>();

        if (await profileRepository.GetByEmailAsNoTrackingAsync(request.Email) is not null)
            throw new AlreadyExistsException($"Profile with email {request.Email} already exists.");

        Profile profile = Profile.Create(request.Email, ProfileType.Admin);

        _passwordService.GeneratePassword(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
        profile.Update(new ProfileUpdateParams(passwordSalt, passwordHash, request.PhoneNumber));

        await profileRepository.CreateAsync(profile);
        await _unitOfWork.SaveChangesAsync();

        await _emailerService.Send(new EmailMessage
        {
            To = [new EmailAddress("remigiusz.cyron@odbiorca.pl")],
            Subject = "Test",
            Body = "<h1>Email header</h1><p>First amail test</p>"
        });

        return new AuthenticationResult(profile.Adapt<ProfileDto>(), _jwtTokenService.GenerateToken(profile));
    }
}
