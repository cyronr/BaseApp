using BaseApp.Application.Features.AuthenticationFeatures.Common;
using BaseApp.Application.Persistence;
using BaseApp.Application.Persistence.Repositories;
using BaseApp.Application.Services;
using BaseApp.Domain.Entities.ProfileEntities;
using BaseApp.Domain.EntitiesParams.UpdateParams;
using BaseApp.Domain.Exceptions;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BaseApp.Application.Features.AuthenticationFeatures.Commands.CreateAdminProfile;

internal class CreateAdminProfileCommandHandler(ILogger<CreateAdminProfileCommandHandler> _logger,
    IUnitOfWork _unitOfWork,
    IPasswordService _passwordService,
    IJwtTokenService _jwtTokenService) : IRequestHandler<CreateAdminProfileCommand, AuthenticationResult>
{
    #region DI
    private readonly ILogger<CreateAdminProfileCommandHandler> _logger = _logger;
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IPasswordService _passwordService = _passwordService;
    private readonly IJwtTokenService _jwtTokenService = _jwtTokenService;
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

        return new AuthenticationResult(profile.Adapt<ProfileDto>(), _jwtTokenService.GenerateToken(profile));
    }
}
