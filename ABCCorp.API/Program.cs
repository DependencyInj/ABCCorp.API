using ABCCorp.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
//// Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddMicrosoftIdentityWebApi(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options);
    options.Events = new JwtBearerEvents()
    {
        OnTokenValidated = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

            var scopeClaim = context.Principal?.Claims.FirstOrDefault(c => c.Type == "scp")?.Value;

            if(scopeClaim != null)
            {
                logger.LogInformation("scope" + scopeClaim);
            } else
            {
                logger.LogInformation("scope not found");
            }
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError("auth failed " + context.Exception.Message);
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError("challenge " + context.ErrorDescription);
            return Task.CompletedTask;
        }
    };


}, options => { builder.Configuration.Bind("AzureAdB2C", options); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("localhost", builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("localhost");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

