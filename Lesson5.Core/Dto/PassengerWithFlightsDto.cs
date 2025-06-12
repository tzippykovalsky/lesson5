using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Core.Dto
{
    public class PassengerWithFlightsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PassportNumber { get; set; }

        public List<FlightDto> Flights { get; set; } = new();
    }
}
