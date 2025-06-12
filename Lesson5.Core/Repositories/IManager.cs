using Lesson5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Core.Repositories
{
    public interface IManager
    {
        public IRepository<Passenger> PassengerRepository { get; set; }
        public IRepository<Pilot> PilotRepository { get; set; }
        public IRepository<Flight> FlightRepository { get; set; }
    }
}
