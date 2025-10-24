using BEAUTIFY.APPLICATION.INTERFACE;
using BEAUTIFY.INFRASTRCTURE.REPOSITORY;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAUTIFY.INFRASTRCTURE.SERVICE_REGISTRY
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection builder)
        {
            builder.AddScoped<ITokenRepository, TokenRepositoryImpl>();
            builder.AddScoped<IAuthRepository, AuthRepositoryImpl>();
        }
    }
}
