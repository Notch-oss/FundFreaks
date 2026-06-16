using EntrePreneurServiceAPI.Models;
using EntrePreneurServiceAPI.Repository;
using EntrePreneurServiceAPI.Service;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<EntrePreneurDatabaseSetting>(
                builder.Configuration.GetSection("EntrePreneurDatabaseSetting"));

//builder.Services.AddSingleton<IEntrePreneurDatabaseSetting>(sp =>
   // sp.GetRequiredService<IOptions<EntrePreneurDatabaseSetting>>().Value);

//builder.Services.AddSingleton<IMongoClient>(s =>
      //  new MongoClient(builder.Configuration.GetValue<string>("EntrePreneurDatabaseSetting:ConnectionString")));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.Configure<ProductDatabaseSetting>(
                builder.Configuration.GetSection("ProductDatabaseSetting"));
builder.Services.AddDiscoveryClient();
//builder.Services.AddSingleton<IProductDatabaseSetting>(sp =>
// sp.GetRequiredService<IOptions<ProductDatabaseSetting>>().Value);

//builder.Services.AddSingleton<IMongoClient>(s =>
//  new MongoClient(builder.Configuration.GetValue<string>("ProductDatabaseSetting:ConnectionString")));
var Default = "_default";

builder.Services.AddCors((setup) =>
{
    setup.AddPolicy(Default, options =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(Default);

app.UseAuthorization();

app.MapControllers();

app.Run();

