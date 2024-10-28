using FlightReservation.models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservation.infra.data;

public class Db : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Flight>()
            .HasMany(f => f.Tickets)
            .WithOne(t => t.Flight)
            .HasForeignKey(t => t.FlightId)
            .OnDelete(DeleteBehavior.Cascade);


        // modelBuilder.Entity<Flight>().Property(f => f.Price).IsRequired().HasColumnType("decimal(7,2)");
        modelBuilder.Entity<Flight>().Property(f => f.FlightNumber).IsUnicode().IsRequired();
        modelBuilder.Entity<Flight>().Property(f => f.DepartureCity).IsRequired();
        modelBuilder.Entity<Flight>().Property(f => f.ArrivalCity).IsRequired();
        modelBuilder.Entity<Flight>().Property(f => f.DepartureTime).IsRequired();
        modelBuilder.Entity<Flight>().Property(f => f.ArrivalTime).IsRequired();

        modelBuilder.Entity<Ticket>().Property(t => t.Price).IsRequired().HasColumnType("decimal(7,2)");
        modelBuilder.Entity<Ticket>().Property(t => t.PassengerEmail).IsRequired();
        modelBuilder.Entity<Ticket>().Property(t => t.Status).IsRequired();
        modelBuilder.Entity<Ticket>().Property(t => t.PassengerName).IsRequired();
        modelBuilder.Entity<Ticket>().Property(t => t.BookingDate).IsRequired();


    }
}