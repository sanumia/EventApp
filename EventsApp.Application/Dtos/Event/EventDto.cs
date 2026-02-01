using EventsApp.Application.Dtos.Image;

namespace EventsApp.Application.Dtos.Event
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime TimeStart { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public int NumberOfParticipant { get; set; }
        public ImageDto? Image { get; set; }
        public Guid? ImageId { get; set; }
    }
}