using FlightReservation.domain.ticket;

namespace FlightReservation.presentation.ticket.dto;

public class TicketMapper
{
    public Ticket ConvertToEntity(TicketDto dto)
    {
        return new TicketBuilder()
            .SetFlightId(dto.FlightId)
            .SetPrice(dto.Price)
            .SetStatus(Status.Panding)
            .SetPassengerName(dto.PassengerName)
            .SetBookingDate(dto.BookingDate)
            .SetPassengerEmail(dto.PassengerEmail).Build();
    }

    public TicketDto ConvertToDto(Ticket ticket)
    {

        return new TicketDto()
        {
            FlightId = ticket.FlightId,
            BookingDate = ticket.BookingDate,
            PassengerEmail = ticket.PassengerEmail,
            PassengerName = ticket.PassengerName,
            Price = ticket.Price,
        };
    }
}