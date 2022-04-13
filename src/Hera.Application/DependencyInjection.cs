using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Hera.Application.Common.Interfaces;

namespace Hera.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
       
    }
}
