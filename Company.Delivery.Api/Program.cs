using Company.Delivery.Api.AppStart;
using Company.Delivery.Database;
using Company.Delivery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDeliveryControllers();
builder.Services.AddDeliveryApi();
builder.Services.AddApplicationDatabase();
builder.Services.AddServices();

var app = builder.Build();

app.UseDeliveryApi();
app.MapControllers();

app.Run();
