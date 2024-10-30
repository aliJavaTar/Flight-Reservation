using FlightReservation.domain.flight.usecase;
using FlightReservation.domain.ticket;
using FlightReservation.domain.ticket.useCase;
using FlightReservation.infra.data;
using FlightReservation.infra.repository;
using FlightReservation.infra.repository.flight;
using FlightReservation.presentation.dto.flight.mapper;
using FlightReservation.presentation.dto.ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var builderConfiguration = builder.Configuration;


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<AddAndModify>();
builder.Services.AddScoped<Search>();
builder.Services.AddScoped<FlightMapper>(); // Register FlightMapper
builder.Services.AddScoped<TicketMapper>(); 
builder.Services.AddScoped<AddAndModifyTicket>();
builder.Services.AddScoped<Booking>();
builder.Services.AddScoped<Cancelling>();

builder.Services.AddDbContext<DataBase>(options =>
    options.UseNpgsql(builderConfiguration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flight", Version = "v1" }); });

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();


app.Run();