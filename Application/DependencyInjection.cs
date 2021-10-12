using ConcurrencyBasicExample.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ConcurrencyBasicService, ConcurrencyBasicService>();
            services.AddScoped<ConcurrencyCheckAttributeTokenService, ConcurrencyCheckAttributeTokenService>();
            services.AddScoped<ConcurrencyRowVersionService, ConcurrencyRowVersionService>();

            return services;
        }
    }
}
