using BaseApp.Domain.Entities.ProfileEntities;

namespace BaseApp.Application.Services;

public interface IJwtTokenService
{
    string GenerateToken(Profile profile);
    Guid GetProfileUUIDByToken(string token);
}
