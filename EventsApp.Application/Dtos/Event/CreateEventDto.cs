
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EventsApp.Application.Dtos.Event
{
    public class CreateEventDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1200)]
        public string Description { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public string? Location { get; set; }

        public string? Category { get; set; }

        [Required]
        [Range(1, 10000)]
        public int NumberOfParticipant {  get; set; }

        public IFormFile? Image { get; set; }

    }
}