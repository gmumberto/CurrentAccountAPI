using System.Diagnostics.CodeAnalysis;

namespace CurrentAccountAPI.Api.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowAnyOrigin();
                });
            });

            return services;
        }
    }
}
