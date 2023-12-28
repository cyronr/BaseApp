using BaseApp.Application.Common;
using BaseApp.Application.Common.Http;
using BaseApp.Application.Common.MessageSenders;
using BaseApp.Application.Persistence;
using BaseApp.Application.Persistence.Repositories;
using BaseApp.Application.Services;
using BaseApp.Domain.Entities.ProfileEntities;
using BaseApp.Infrastructure.Common;
using BaseApp.Infrastructure.Common.Classes;
using BaseApp.Infrastructure.Common.Http;
using BaseApp.Infrastructure.Common.MessageSenders;
using BaseApp.Infrastructure.Persistence;
using BaseApp.Infrastructure.Persistence.Repositories;
using BaseApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAppSettings(configuration);

        services.ConfigureServices();
        services.ConfigurePersistance();
        services.ConfigureCommonDependencyInjection();

        services.AddDbContext<AppDbContext>();

        return services;
    }

    private static IServiceCollection AddAppSettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettings.SectionName));
        services.Configure<SmtpConfig>(configuration.GetSection(nameof(SmtpConfig)));

        return services;
    }

    private static IServiceCollection ConfigurePersistance(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();

        services.AddScoped<IRepository<Profile>, ProfileRepository>();

        return services;
    }

    private static IServiceCollection ConfigureCommonDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddSingleton<IHttpRequester, HttpRequester>();
        services.AddSingleton<IEmailSender, EmailSender>();

        return services;
    }

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        services.AddSingleton<IPasswordService, PasswordService>();

        return services;
    }
}
