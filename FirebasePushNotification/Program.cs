using FirebasePushNotification.Implements;
using FirebasePushNotification.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

// Add services to the container.
service.AddTransient<IPushService, PushService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
