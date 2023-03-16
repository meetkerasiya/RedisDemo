using APIwithRedis.API;
using APIwithRedis.CacheService;
using APIwithRedis.CacheSetup;
using APIwithRedis.Models;
using APIwithRedis.Repository;
using APIwithRedis.Validation;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(redisoptions =>
{
    string connection = builder.Configuration.GetConnectionString("Redis");
    redisoptions.Configuration = connection;
    redisoptions.InstanceName = "RedisPayment";
});

builder.Services.AddScoped<ICacheService<List<PaymentOptions>>,CacheService<List<PaymentOptions>>>();
builder.Services.AddScoped<IValidator<PaymentOptions>, Validator>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<ICacheSetup,CacheSetup>();


var app = builder.Build();


//route
APIRoutes.MapRoutes(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
