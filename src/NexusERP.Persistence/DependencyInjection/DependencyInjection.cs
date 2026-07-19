using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexusERP.Application.Common.Interfaces;
using NexusERP.Application.Interfaces;
using NexusERP.Persistence.Authentication;
using NexusERP.Persistence.Contexts;
using NexusERP.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Persistence.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            // Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            // Authentication
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
            return services;
        }
    }
}
