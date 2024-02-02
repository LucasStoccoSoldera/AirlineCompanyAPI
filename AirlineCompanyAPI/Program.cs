using AirlineCompanyAPI.Config;
using AirlineCompanyAPI.Config.Docs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var applicationData = new ApplicationData(builder.Configuration);

// Documentation
var swaggerConfig = new SwaggerConfig(applicationData);
swaggerConfig.Configure(builder.Services);

// Injection
builder.Services.AddSingleton(applicationData);
builder.Services.AddSingleton(swaggerConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    swaggerConfig.Enable(app);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
