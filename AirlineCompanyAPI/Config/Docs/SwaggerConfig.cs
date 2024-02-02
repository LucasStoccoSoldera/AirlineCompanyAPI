using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AirlineCompanyAPI.Config.Docs
{
    internal class SwaggerConfig(ApplicationData applicationData) : ISwaggerConfig
    {

        public void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                SetApiInfo(option);
                SetSecurityDefinition(option);
                SetSecurityRequirement(option);
            });
        }
        public void SetApiInfo(SwaggerGenOptions option)
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
        }

        public void SetSecurityDefinition(SwaggerGenOptions option)
        {
            OpenApiSecurityScheme securityDefinition = new()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            };
            option.AddSecurityDefinition("Bearer", securityDefinition);
        }

        public void SetSecurityRequirement(SwaggerGenOptions option)
        {
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
