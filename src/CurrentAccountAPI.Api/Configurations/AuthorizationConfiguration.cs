using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace CurrentAccountAPI.Api.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class AuthorizationConfiguration
    {
        // Define policy names as constants
        public const string ServicePolicyName = "Service";
        public const string DefaultPolicyName = "Default";

        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                // Service policy
                options.AddPolicy(ServicePolicyName, policy =>
                    policy.RequireAuthenticatedUser()
                          .RequireRole("role-service"));

                // Default policy
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireRole("user-permission")
                    .Build();
            });

            return services;
        }
    }
}
