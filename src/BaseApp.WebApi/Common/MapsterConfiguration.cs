using BaseApp.Application.Features.AuthenticationFeatures.Common;
using Mapster;
using BaseApp.WebAPI.Responses.AuthenticationResponses;

namespace BaseApp.WebAPI.Common;

internal static class MapsterConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<ProfileDto, AuthenticationResponseProfile>.NewConfig()
            .Map(dest => dest.ProfileType.Id, src => (int)src.ProfileType)
            .Map(dest => dest.ProfileType.Name, src => src.ProfileType.ToString());
    }
}
