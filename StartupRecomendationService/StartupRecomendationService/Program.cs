 
using Neo4j.Driver;
using Neo4jClient;
using StartupRecomendationService.Models;
using StartupRecomendationService.Repository;
using StartupRecomendationService.Service;
using Serilog;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var Default = "_default";
builder.Services.AddCors((setup) =>
{
    setup.AddPolicy(Default, options =>
    {
        options.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new[] { "https://localhost:4200" })
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});
var neo4jUri = builder.Configuration.GetValue<string>("Neo4j:Uri") ?? "bolt://localhost:7687";
var neo4jUsername = builder.Configuration.GetValue<string>("Neo4j:Username") ?? "neo4j";
var neo4jPassword = builder.Configuration.GetValue<string>("Neo4j:Password") ?? "password";
var client = new BoltGraphClient(new Uri(neo4jUri), neo4jUsername, neo4jPassword);
client.ConnectAsync();
builder.Services.AddSingleton<IGraphClient>(client);
builder.Services.AddSingleton<IHostedService, KafkaConsumerService>();
builder.Services.AddDiscoveryClient();
builder.Services.AddScoped<IInvestorRecomendationRepository, InvestorRecomendationRepository>();
builder.Services.AddScoped<IInvestorRecomendationService, InvestorRecomendationService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)); 

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(Default);

app.Run();
