using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Data.Repositories
{
    public class Manager : IManager
    {
        public IRepository<Passenger> PassengerRepository { get; set; }
        public IRepository<Pilot> PilotRepository { get; set; }
        public IFlightRepository FlightRepository { get; set; }
        public Manager(IRepository<Passenger> passengerRepository, IRepository<Pilot> pilotRepository, IFlightRepository flightRepository)
        {
            PassengerRepository = passengerRepository;
            PilotRepository = pilotRepository;
            FlightRepository = flightRepository;

        }
    }
}
