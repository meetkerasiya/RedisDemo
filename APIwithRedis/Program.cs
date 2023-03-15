using APIwithRedis.API;
using APIwithRedis.DBSetup;

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


await Redis_Data_seed.DataSeed(builder);

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
