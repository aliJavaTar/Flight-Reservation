namespace FlightReservation.presentation.flight.dto;

public class FlightSearchDto : FlightUpdateRequest
{
    public int PageNumber { get; set; } = 1;  // Default to first page
    public int PageSize { get; set; } = 10;   // Default to 10 items per page
    public SortBy SortBy { get; set; } = SortBy.DepartureTime;  // Default to DepartureTime
    public SortOrder SortOrder { get; set; } = SortOrder.Ascending; 
}