using FlightReservation.domain.useCase.flight;
using FlightReservation.domain.useCase.ticket;
using FlightReservation.infra.data;
using FlightReservation.infra.repository;
using FlightReservation.infra.repository.flight;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var builderConfiguration = builder.Configuration;


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddSingleton<AddAndModify>();
builder.Services.AddSingleton<Search>();
builder.Services.AddSingleton<AddAndModifyTicket>();
builder.Services.AddSingleton<Booking>();
builder.Services.AddSingleton<Cancelling>();

var app = builder.Build();
builder.Services.AddDbContext<Db>(options =>
    options.UseNpgsql(builderConfiguration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flight", Version = "v1" }); });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();