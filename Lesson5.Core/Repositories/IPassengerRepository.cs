using Lesson5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Core.Repositories
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        List<Flight> GetFlightsForPassenger(int passengerId);
        bool IsPassengerInFlight(int passengerId, int flightId);
    }

}
