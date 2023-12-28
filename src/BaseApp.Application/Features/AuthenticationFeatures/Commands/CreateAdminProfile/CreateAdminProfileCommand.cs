using BaseApp.Application.Features.AuthenticationFeatures.Common;
using MediatR;

namespace BaseApp.Application.Features.AuthenticationFeatures.Commands.CreateAdminProfile;

public record CreateAdminProfileCommand
(
    string Email,
    string Password,
    string? PhoneNumber
) : IRequest<AuthenticationResult>;
