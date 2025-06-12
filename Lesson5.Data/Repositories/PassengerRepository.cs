using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson5.Data.Repositories
{
    public class PassengerRepository :Repository<Passenger>, IPassengerRepository
    {
       
        public PassengerRepository(DataContext dataContext):base(dataContext)
        {
           
        }
        public List<Flight> GetFlightsForPassenger(int passengerId)
        {
            var passenger = _dbSet
                .Include(p => p.Flights)
                .FirstOrDefault(p => p.Id == passengerId);

            return passenger?.Flights ?? new List<Flight>();
        }

        public bool IsPassengerInFlight(int passengerId, int flightId)
        {
            var passenger = _dbSet
                .Include(p => p.Flights)
                .FirstOrDefault(p => p.Id == passengerId);

            return passenger?.Flights.Any(f => f.Id == flightId) == true;
        }
    }
}
