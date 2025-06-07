using Lesson5.Core.Entities;
using Lesson5.Data.Repositories;

namespace Lesson5.Service
{
    public class FlightService
    {
        private readonly FlightRepository _flightRepository;
        private readonly PilotRepository _pilotRepository;

        public FlightService(FlightRepository flightRepository, PilotRepository pilotRepository)
        {
            _flightRepository = flightRepository;
            _pilotRepository = pilotRepository;
        }

        public List<Flight> GetFlights()
        {
            return _flightRepository.GetFlights();
        }

        public Flight? GetFlightById(int id)
        {
            return _flightRepository.GetFlightById(id);
        }

        public void AddFlight(Flight flight)
        {
            if (flight.Price <= 0)
                throw new ArgumentException("מחיר הטיסה חייב להיות מספר חיובי.");

            if (string.IsNullOrWhiteSpace(flight.Destination))
                throw new ArgumentException("יש להזין יעד לטיסה.");

            // מספר שעות לא חוקי
            if (flight.NumHours <= 0 || flight.NumHours > 24)
                throw new ArgumentException("מספר שעות חייב להיות בין 1 ל-24.");

            // בדיקה שהטייס קיים
            var pilot = _pilotRepository.GetPilotById(flight.PilotId);
            if (pilot == null)
                throw new InvalidOperationException("טייס לא קיים במערכת.");

            // לא לאפשר טיסה כפולה באותו שער, יעד וטייס
            var existingFlights = _flightRepository.GetFlights();
            bool conflict = existingFlights.Any(f =>
                f.Gate == flight.Gate &&
                f.Destination == flight.Destination &&
                f.PilotId == flight.PilotId);

            if (conflict)
                throw new InvalidOperationException("כבר קיימת טיסה דומה במערכת עם אותו טייס, יעד ושער.");

            _flightRepository.AddFlight(flight);
        }

        public void RemoveFlight(int id)
        {
            _flightRepository.RemoveFlight(id);
        }

        public void UpdateFlight(Flight flight)
        {
            // אפשר להוסיף לוגיקות גם כאן כמו בבדיקה של Add
            _flightRepository.UpdateFlight(flight);
        }

        public void UpdateFlight(Flight flight, int id)
        {
            var existing = GetFlightById(id);
            if (existing == null)
                throw new KeyNotFoundException($"Flight with ID {flight.Id} does not exist.");

            // עדכון שדות לפי מה שנשלח, רק אם לא null/ריק
            if (!string.IsNullOrWhiteSpace(flight.Destination))
                existing.Destination = flight.Destination;

            if (!string.IsNullOrWhiteSpace(flight.Gate))
                existing.Gate = flight.Gate;
            //if (!string.IsNullOrWhiteSpace(flight.PilotId))//צריך לבדוק לפני שנותנים לעדכן קוד טייס שאכן נמצא TODO
            //    existing.PilotId = flight.PilotId;

            if (flight.Price > 0)
                existing.Price = flight.Price;
            if (flight.NumHours > 0)
                existing.NumHours = flight.NumHours;
            if (flight.Terminal > 0)
                existing.Terminal = flight.Terminal;


            _flightRepository.UpdateFlight(existing);
        }
    }
}
