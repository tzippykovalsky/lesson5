using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Data.Repositories
{
    public class PilotRepository : IPilotRepository
        //בשכבה זו נבצע רק לוגיקה שקשורה למסד התנונים בלבד
    {
        private readonly DataContext _dataContext;
        public PilotRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Pilot> GetAll()
        {
            return _dataContext.Pilots.ToList();
        }

        public Pilot? GetById(int id)
        {
            return _dataContext.Pilots.FirstOrDefault(f => f.Id == id);
        }

        public void Add(Pilot pilot)
        {
            _dataContext.Pilots.Add(pilot);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = GetById(id);
            _dataContext.Remove(p);
            _dataContext.SaveChanges();
        }
        public void Update(Pilot pilot)
        {
            _dataContext.Update(pilot);
            _dataContext.SaveChanges();
        }
    }
}
