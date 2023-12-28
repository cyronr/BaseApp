using BaseApp.Application.Features.AuthenticationFeatures.Common;
using MediatR;

namespace BaseApp.Application.Features.AuthenticationFeatures.Queries.Login
{
    public record LoginQuery
    (
        string Email,
        string Password
    ) : IRequest<AuthenticationResult>;
}
