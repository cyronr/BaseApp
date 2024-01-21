using BaseApp.Domain.Entities.ProfileEntities;

namespace BaseApp.Application.Services.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(Profile profile);
    Guid GetProfileUUIDByToken(string token);
}
