using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application.Dtos.Image
{
    public class UpdateImageDto
    {
        public IFormFile? File { get; set; }
        public string? Description { get; set; }
    }
}
