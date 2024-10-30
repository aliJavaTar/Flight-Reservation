using FlightReservation.domain.flight.usecase;
using FlightReservation.domain.ticket;
using FlightReservation.domain.ticket.useCase;
using FlightReservation.infra.auth;
using FlightReservation.infra.data;
using FlightReservation.infra.repository;
using FlightReservation.infra.repository.flight;
using FlightReservation.infra.repository.ticket;
using FlightReservation.presentation.mapper;
using FlightReservation.presentation.ticket.dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var builderConfiguration = builder.Configuration;


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AddAndModify>();
builder.Services.AddScoped<Search>();
builder.Services.AddScoped<FlightMapper>();
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