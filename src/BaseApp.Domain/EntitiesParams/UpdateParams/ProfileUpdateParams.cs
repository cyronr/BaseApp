using BaseApp.Domain.Entities.ProfileEntities;

namespace BaseApp.Domain.EntitiesParams.UpdateParams;

/// <summary>
/// Update params used to update Profile entity
/// </summary>
/// <param name="passwordSalt"></param>
/// <param name="passwordHash"></param>
/// <param name="phoneNumber"></param>
public record ProfileUpdateParams(
    byte[]? passwordSalt = default,
    byte[]? passwordHash = default,
    string? phoneNumber = default) : BaseUpdateParams<ProfileUpdateParams, Profile>;
