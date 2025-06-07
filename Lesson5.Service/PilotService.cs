using Lesson5.Core.Entities;
using Lesson5.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Service
{
    public class PilotService
    //שכבה זו תכלול לוגיקה עסקית שכוללת אימות נתונים ובדיקות שונות
    {
        private readonly PilotRepository _pilotRepository;

        public PilotService(PilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public List<Pilot> GetPilots()
        {
            return _pilotRepository.GetPilots();
        }
        public Pilot? GetPilotById(int id)
        {
            return _pilotRepository.GetPilotById(id);
        }
        public void AddPilot(Pilot pilot)
        {
            // ולידציה בסיסית
            if (string.IsNullOrWhiteSpace(pilot.Name))
                throw new ArgumentException("Pilot name is required.");

            if (pilot.Age < 18 || pilot.Age > 70)
                throw new ArgumentException("Pilot age must be between 18 and 70.");

            // בדיקה אם הטייס כבר קיים לפי ת"ז
            if (_pilotRepository.GetPilots().FirstOrDefault(p=>p.IdentityNumber.Equals(pilot.IdentityNumber))!=null)
                throw new InvalidOperationException("Pilot with the same identity number already exists.");

            // אם הכל תקין - מוסיפים
            _pilotRepository.AddPilot(pilot);
        }
        public void RemovePilot(int id)
        {
            var existing = _pilotRepository.GetPilotById(id);
            if (existing == null)
                throw new KeyNotFoundException($"Pilot with ID {id} not found.");

            _pilotRepository.RemovePilot(id);
        }
        public void UpdatePilot(Pilot pilot,int id)
        {
            var existing = GetPilotById(id);
            if (existing == null)
                throw new KeyNotFoundException($"Pilot with ID {pilot.Id} does not exist.");

            // לא לשנות ת"ז (identity number)
            if (pilot.IdentityNumber != null && pilot.IdentityNumber != existing.IdentityNumber)
                throw new InvalidOperationException("Cannot change pilot's identity number.");

            // עדכון שדות לפי מה שנשלח, רק אם לא null/ריק
            if (!string.IsNullOrWhiteSpace(pilot.Name))
                existing.Name = pilot.Name;

            if (pilot.Age > 0)
                existing.Age = pilot.Age;

            if (!string.IsNullOrWhiteSpace(pilot.Email))
                existing.Email = pilot.Email;

            // כאן לא נגע ב-Flights כדי לא למחוק אותם במקרה שלא נשלחו

            _pilotRepository.UpdatePilot(existing); // הרפוזיטורי שומר את השינויים
        }

    }
}
