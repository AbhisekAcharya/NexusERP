using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexusERP.Application.Common.Interfaces;
using NexusERP.Infrastructure.Authentication;
using NexusERP.Infrastructure.Email;

namespace NexusERP.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Authentication
            services.AddScoped<IPasswordResetTokenGenerator, PasswordResetTokenGenerator>();
            services.Configure<BrevoSettings>(configuration.GetSection(BrevoSettings.SectionName));
            services.AddHttpClient<BrevoEmailService>();
            services.AddScoped<IEmailService>(sp => sp.GetRequiredService<BrevoEmailService>());
            return services;
        }
    }
}
