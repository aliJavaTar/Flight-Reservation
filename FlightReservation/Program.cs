using System.Text;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Ensures the token was issued by a trusted source
            ValidateAudience = true, // Ensures the token is intended for a specific audience
            ValidateLifetime = true, // Checks if the token has expired
            ValidateIssuerSigningKey = true, // Ensures the token is signed correctly
            
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication(); // Ensures the JWT middleware validates tokens
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();


app.Run();