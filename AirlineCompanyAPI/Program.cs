using AirlineCompanyAPI.Config;
using AirlineCompanyAPI.Config.Docs;
using AirlineCompanyAPI.Exceptions.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var applicationData = new ApplicationData(builder.Configuration);

// Documentation
var swaggerConfig = new SwaggerConfig(applicationData);
swaggerConfig.Configure(builder.Services);

// Exeception handling
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<InternalServerErrorExceptionHandler>();
builder.Services.AddExceptionHandler<NotImplementedExceptionHandler>();
builder.Services.AddExceptionHandler<UnauthorizedExceptionHandler>();

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
