using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AirlineCompanyAPI.Config.Docs
{
    public interface ISwaggerConfig
    {
        public void Configure(IServiceCollection services);
        public void SetApiInfo(SwaggerGenOptions option);
        public void SetSecurityDefinition(SwaggerGenOptions option);
        public void SetSecurityRequirement(SwaggerGenOptions option);
        public void Enable(IApplicationBuilder app);
    }
}
