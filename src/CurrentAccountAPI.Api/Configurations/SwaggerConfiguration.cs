using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;

namespace CurrentAccountAPI.Api.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var kubernetesPath = configuration["IngressPath"];
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CurrentAccountAPI Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                if (!string.IsNullOrEmpty(kubernetesPath))
                    c.DocumentFilter<KubernetesPathPrefixFilter>(kubernetesPath);
            });
            return services;
        }

        internal sealed class KubernetesPathPrefixFilter : IDocumentFilter
        {
            private readonly string _pathPrefix;

            public KubernetesPathPrefixFilter(string prefix) =>
                _pathPrefix = prefix;

            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                var paths = swaggerDoc.Paths.Keys.ToList();
                foreach (var path in paths)
                {
                    var pathToChange = swaggerDoc.Paths[path];
                    swaggerDoc.Paths.Remove(path);
                    swaggerDoc.Paths.Add($"{_pathPrefix}{path}", pathToChange);
                }
            }
        }
    }
}