using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson5.Data.Repositories
{
    //בדף זה נגדיר את כל הפעולות שנרצה לבצע על ה  dbset של טיסות
    public class FlightRepository : IFlightRepository
    {
        private readonly DataContext _dataContext;
        public FlightRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Flight> GetAll()
        {
            return _dataContext.Flights.ToList();
        }

        public Flight? GetById(int id)
        {
            return _dataContext.Flights.FirstOrDefault(f => f.Id == id);
        }

        public void Add(Flight flight)
        {
            _dataContext.Flights.Add(flight);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var f=GetById(id);
            _dataContext.Remove(f);//
            _dataContext.SaveChanges();
        }
        public void Update(Flight flight)
        {
            //var f = GetFlightById(flight.Id);
            _dataContext.Update(flight);
            _dataContext.SaveChanges();
        }
    }
}
