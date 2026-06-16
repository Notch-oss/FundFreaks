using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Steeltoe.Discovery.Client;
var builder = WebApplication.CreateBuilder(args);


//1
builder.Configuration.AddJsonFile("ocelot.json");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//2
builder.Services.AddOcelot();

builder.Services.AddDiscoveryClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//3
app.UseOcelot().Wait();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
