using Lesson5.Api.Controllers;
using Lesson5.Core.Repositories;
using Lesson5.Data;
using Lesson5.Data.Repositories;
using Lesson5.Service;
using Lesson5.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<PilotService>();
//builder.Services.AddScoped<FlightService>();
//builder.Services.AddScoped<PassengerService>();
//builder.Services.AddScoped<IPilotRepository,PilotRepository>();
//builder.Services.AddScoped<IFlightRepository,FlightRepository>();
//builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();

//builder.Services.AddDbContext<DataContext>();
builder.Services.setService();
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
