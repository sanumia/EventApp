using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application.Dtos.Image
{
    public class UploadImageDto
    {
        [Required]
        public IFormFile File { get; set; } = null!;
        [StringLength(200)]
        public string? Description { get; set; }
    }
}
