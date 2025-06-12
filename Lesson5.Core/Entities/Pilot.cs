using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Core.Entities
{
    public class Pilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public List<Flight>? Flights { get; set; } = new();

    }
}
