using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Domain.Entities
{
    public class Image:BaseEntity
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size   { get; set; }
        public byte[]  Data { get; set; }

    }
}
