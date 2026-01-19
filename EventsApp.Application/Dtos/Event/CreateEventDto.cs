
using System.ComponentModel.DataAnnotations;

namespace EventsApp.Application.Dtos.Event
{
    public class CreateEventDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1200)]
        public string Description { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public int NumberOfParticipant {  get; set; }

        public byte[]? Image { get; set; }

    }
}