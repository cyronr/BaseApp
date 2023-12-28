using Application;
using BaseApp.Application.Common.AppProfile;
using BaseApp.Application.Common.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICurrentLoggedProfile, CurrentLoggedProfile>();

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<BaseAppApplication>();
        services.RegisterMapsterConfiguration();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BaseAppApplication).Assembly));

        return services;
    }
}
