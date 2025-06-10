using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson5.Data.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly DataContext _dataContext;
        public PassengerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Passenger> GetAll()
        {
            return _dataContext.Passes.ToList();
        }

        public Passenger? GetById(int id)
        {
            return _dataContext.Passes.FirstOrDefault(f => f.Id == id);
        }

        public void Add(Passenger passenger)
        {
            _dataContext.Passes.Add(passenger);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var f=GetById(id);
            _dataContext.Remove(f);//
            _dataContext.SaveChanges();
        }
        public void Update(Passenger passenger)
        {
            //var f = GetFlightById(flight.Id);
            _dataContext.Update(passenger);
            _dataContext.SaveChanges();
        }
    }
}
