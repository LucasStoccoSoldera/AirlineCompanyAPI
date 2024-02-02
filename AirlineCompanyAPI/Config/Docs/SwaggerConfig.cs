using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace AirlineCompanyAPI.Config.Docs
{
    internal class SwaggerConfig(IConfiguration configuration)
    {
        private readonly ApplicationData applicationData = new(configuration);
        public void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                OpenApiInfo apiInfo = new()
                {
                    Title = applicationData.Name,
                    Version = applicationData.Version,
                    Description = applicationData.Description,
                };
                if (applicationData.Contact?.Url != null)
                {
                    apiInfo.Contact = new OpenApiContact
                    {
                        Name = applicationData.Contact.Name,
                        Url = new Uri(applicationData.Contact.Url)
                    };
                }
                option.SwaggerDoc(
                    applicationData.Version,
                    apiInfo
                );

                OpenApiSecurityScheme securityDefinition = new()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };
                option.AddSecurityDefinition("Bearer", securityDefinition);

                OpenApiSecurityRequirement securityRequirement = new()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                };  
                option.AddSecurityRequirement(securityRequirement);
            });
        }

        public void Enable(IApplicationBuilder app)
        {
            app.UseSwagger(option =>
            {
                option.RouteTemplate = "docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint($"/docs/{applicationData.Version}/swagger.json", "AirlineCompanyAPI");
                option.RoutePrefix = "docs";
            });
        }
    }
}
