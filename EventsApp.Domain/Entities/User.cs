using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Domain.Entities
{
    public class User:BaseEntity
    {
        public string? Name { get; set; }
        public DateOnly Birthday { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public string? Email {  get; set; }
    }
}
