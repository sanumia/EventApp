
using System.ComponentModel.DataAnnotations;


namespace EventsApp.Application.Dtos.Event
{
    public class UpdateEventDto
    {
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1200)]
        public string Description { get; set; }

        public DateTime TimeStart { get; set; }

        public string? Location { get; set; }

        public int NumberOfParticipant { get; set; }

        public byte[]? Image { get; set; }
    }
}
