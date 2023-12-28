using BaseApp.Domain.Entities.ProfileEntities;

namespace BaseApp.Application.Persistence.Repositories;

public interface IProfileRepository : IRepository<Profile>
{
    Task<Profile?> GetByEmailAsync(string email);
    Task<Profile?> GetByEmailAsNoTrackingAsync(string email);
    Task<ProfileEvent?> GetLastEventAsync(Profile profile, ProfileEventType profileEvent);
}
