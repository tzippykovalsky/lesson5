using Lesson5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Core.Repositories
{
    public interface IFlightRepository : IRepository<Flight>
    {
        void AddPassengerToFlight(int flightId, Passenger passenger);
        void RemovePassengerFromFlight(int flightId, int passengerId);
        List<Passenger> GetPassengersInFlight(int flightId);
        List<Flight> GetFlightsByDestination(string destination);
        List<Flight> GetFlightsByPilotId(int pilotId);
    }
}
