using System;
using Aula_API.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Aula_API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Register your services and dependencies here.
            services.AddScoped<IApiKeyValidation, ApiKeyValidation>();
            // Add other service registrations...
        }
    }

}

