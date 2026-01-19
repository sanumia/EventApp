using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Domain.Entities
{
    public class Event:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime TimeStart { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public int NumberOfParticipant {  get; set; }
        public byte[]? Image { get; set; }
    }
}
