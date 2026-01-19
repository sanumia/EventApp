
using System.ComponentModel.DataAnnotations;

namespace EventsApp.Application.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public DateOnly Birthday { get; set; }
        public string? Email { get; set; }
        
    }
}
