using Lesson5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Data.Repositories
{
    //בדף זה נגדיר את כל הפעולות שנרצה לבצע על ה  dbset של טיסות
    public class FlightRepository
    {
        private readonly DataContext _dataContext;
        public FlightRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Flight> GetFlights()
        {
            return _dataContext.Flights.ToList();
        }

        public Flight? GetFlightById(int id)
        {
            return _dataContext.Flights.FirstOrDefault(f => f.Id == id);
        }

        public void AddFlight(Flight flight)
        {
            _dataContext.Flights.Add(flight);
            _dataContext.SaveChanges();
        }

        public void RemoveFlight(int id)
        {
            var f=GetFlightById(id);
            _dataContext.Remove(f);
            _dataContext.SaveChanges();
        }
        public void UpdateFlight(Flight flight)
        {
            //var f = GetFlightById(flight.Id);
            _dataContext.Update(flight);
            _dataContext.SaveChanges();
        }
    }
}
