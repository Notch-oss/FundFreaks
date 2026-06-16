using Investor_Service.Logger;
using Investor_Service.Models;
using Investor_Service.Repository;
using Investor_Service.Service;
using Microsoft.Extensions.Options;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UserContext>(
    builder.Configuration.GetSection("InvestorDatabase"));

builder.Services.AddSingleton<UserContext>(sp =>
                sp.GetRequiredService<IOptions<UserContext>>().Value);

builder.Services.AddSingleton<IInvestorService, InvestorService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<LoggingAspect>();
builder.Services.AddSingleton<UserContext>();
builder.Services.AddDiscoveryClient();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new[] { "https://localhost:4200" })
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
