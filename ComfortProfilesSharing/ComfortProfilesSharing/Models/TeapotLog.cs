using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class TeapotLog
    {
        public Guid Id { get; set; }
        
        public Guid TeapotId { get; set; }
        public Teapot Teapot { get; set; }
        
        public DateTime Date { get; set; }

        public int Temperature { get; set; }
        public bool? IsRepeatable { get; set; }

        public Guid HowOftenId { get; set; }
        public HowOften HowOften { get; set; }
    }
}
