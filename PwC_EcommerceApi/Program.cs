using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PwC_EcommerceApi.Context;
using PwC_EcommerceApi.Controllers;
using PwC_EcommerceApi.DataAccess.Utility;
using PwC_EcommerceApi.DataAccess;
using PwC_EcommerceApi.Repository;
using System;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDBContext>();
builder.Services.AddScoped(typeof(OrderRepository<>));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<ICosmosConnection, CosmosConnection>();
builder.Services.AddTransient<ICosmosDataAdapter, CosmosDataAdapter>();

//var connectionString = "mongodb://pwctask:ngnXXXtqv690HqT7uWP7xIR16hgMdSaSplsuzF5V0w91EK9VIRSa3ntsGEIpRbOayStYuz6URcydACDbvg9RMg==@pwctask.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@pwctask@";
//var dbName = "Ecommerce";
//var endPoint = "https://pwctask.mongo.cosmos.azure.com:443/";

//MongoClientSettings settings = MongoClientSettings.FromUrl(
//  new MongoUrl(connectionString)
//);

//settings.SslSettings =
//  new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
//var mongoClient = new MongoClient(settings);

//builder.Services.AddDbContext<MyDBContext>(option => option.UseCosmos(endPoint,connectionString, dbName));

//builder.Services.AddSingleton<MongoClient>(serviceProvider =>
//{
//    var mongoClient = new MongoClient(settings);
//    var database = mongoClient.GetDatabase(dbName);
//    return mongoClient;
//});


//builder.Services.AddSingleton<MongoClient>(serviceProvider => serviceProvider.);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
