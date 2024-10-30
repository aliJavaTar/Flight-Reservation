using FlightReservation.domain;
using FlightReservation.domain.flight;
using FlightReservation.domain.ticket;
using FlightReservation.infra.models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservation.infra.data;

public class DataBase(DbContextOptions<DataBase> options) : DbContext(options)
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        UserDb(modelBuilder);

        FlightDb(modelBuilder);

        TicketDb(modelBuilder);
    }

    private static void UserDb(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();
        modelBuilder.Entity<User>().HasMany<Ticket>().WithOne(t => t.User).HasForeignKey(t => t.UserId);
    }

    private static void TicketDb(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>().Property(t => t.Price).IsRequired().HasColumnType("decimal(7,2)");
        modelBuilder.Entity<Ticket>().Property(t => t.PassengerEmail).IsRequired();
        modelBuilder.Entity<Ticket>().Property(t => t.Status).IsRequired();
        modelBuilder.Entity<Ticket>().Property(t => t.PassengerName).IsRequired();
        modelBuilder.Entity<Ticket>().Property(t => t.BookingDate).IsRequired();
    }

    private static void FlightDb(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>()
            .HasMany(f => f.Tickets)
            .WithOne(t => t.Flight)
            .HasForeignKey(t => t.FlightId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Flight>().HasIndex().IsUnique();
        modelBuilder.Entity<Flight>().Property(f => f.DepartureCity).IsRequired();
        modelBuilder.Entity<Flight>().Property(f => f.ArrivalCity).IsRequired();
        modelBuilder.Entity<Flight>().Property(f => f.DepartureTime).IsRequired();
        modelBuilder.Entity<Flight>().Property(f => f.ArrivalTime).IsRequired();
    }
}