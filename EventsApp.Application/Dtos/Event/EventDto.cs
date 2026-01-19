

namespace EventsApp.Application.Dtos.Event
{
    public class EventDto
    {
        public string? Description { get; set; }
        public DateTime TimeStart { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public int NumberOfParticipant { get; set; }
        public byte[]? Image { get; set; }
    }
}
