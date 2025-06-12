using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5.Data.Repositories
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {

        public FlightRepository(DataContext context) : base(context)
        {
        
        }

        public void AddPassengerToFlight(int flightId, Passenger passenger)
        {
            var flight = _dbSet
                .Include(f => f.Passengers)
                .FirstOrDefault(f => f.Id == flightId);

            if (flight != null && !flight.Passengers.Any(p => p.Id == passenger.Id))
            {
                flight.Passengers.Add(passenger);
                _context.SaveChanges();
            }
        }

        public void RemovePassengerFromFlight(int flightId, int passengerId)
        {
            var flight = _dbSet
                .Include(f => f.Passengers)
                .FirstOrDefault(f => f.Id == flightId);

            var passenger = flight?.Passengers.FirstOrDefault(p => p.Id == passengerId);

            if (flight != null && passenger != null)
            {
                flight.Passengers.Remove(passenger);
                _context.SaveChanges();
            }
        }

        public List<Passenger> GetPassengersInFlight(int flightId)
        {
            var flight = _dbSet
                .Include(f => f.Passengers)
                .FirstOrDefault(f => f.Id == flightId);

            return flight?.Passengers.ToList() ?? new List<Passenger>();
        }

        public List<Flight> GetFlightsByDestination(string destination)
        {
            return _dbSet
                .Where(f => f.Destination == destination)
                .ToList();
        }

        public List<Flight> GetFlightsByPilotId(int pilotId)
        {
            return _dbSet
                .Where(f => f.PilotId == pilotId)
                .ToList();
        }

    }
}
