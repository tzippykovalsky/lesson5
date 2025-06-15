using AutoMapper;
using Lesson5.Core.Dto;
using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;
using Lesson5.Data.Repositories;

namespace Lesson5.Service
{
    public class FlightService(IManager manager, IMapper mapper)
    {
        public readonly IManager Manager=manager;
        private readonly IMapper _mapper;

        public List<Flight> GetFlights()
        {
            return Manager.FlightRepository.GetAll();
        }

        public Flight? GetFlightById(int id)
        {
            return Manager.FlightRepository.GetById(id);
        }

        public async Task AddFlight(Flight flight)
        {
            if (flight.Price <= 0)
                throw new ArgumentException("מחיר הטיסה חייב להיות מספר חיובי.");

            if (string.IsNullOrWhiteSpace(flight.Destination))
                throw new ArgumentException("יש להזין יעד לטיסה.");

            // מספר שעות לא חוקי
            if (flight.NumHours <= 0 || flight.NumHours > 24)
                throw new ArgumentException("מספר שעות חייב להיות בין 1 ל-24.");

            // בדיקה שהטייס קיים
            var pilot = Manager.PilotRepository.GetById(flight.PilotId);
            if (pilot == null)
                throw new InvalidOperationException("טייס לא קיים במערכת.");

            // לא לאפשר טיסה כפולה באותו שער, יעד וטייס
            var existingFlights = Manager.FlightRepository.GetAll();
            bool conflict = existingFlights.Any(f =>
                f.Gate == flight.Gate &&
                f.Destination == flight.Destination &&
                f.PilotId == flight.PilotId);

            if (conflict)
                throw new InvalidOperationException("כבר קיימת טיסה דומה במערכת עם אותו טייס, יעד ושער.");

            Manager.FlightRepository.Add(flight);
            await Manager.Save();
        }

        public void RemoveFlight(int id)
        {
            Manager.FlightRepository.Delete(id);
            Manager.Save();
        }

        public void UpdateFlight(Flight flight)
        {
            // אפשר להוסיף לוגיקות גם כאן כמו בבדיקה של Add
            Manager.FlightRepository.Update(flight);
            Manager.Save();
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


            Manager.FlightRepository.Update(existing);
            Manager.Save();
        }
        public void AddPassengerToFlight(int flightId, Passenger passenger)
        {
            Manager.FlightRepository.AddPassengerToFlight(flightId, passenger);
            Manager.Save();
        }

        public async void RemovePassengerFromFlight(int flightId, int passengerId)
        {
            Manager.FlightRepository.RemovePassengerFromFlight(flightId, passengerId);
            Manager.Save();
        }

        public List<PostPassengerDto> GetPassengersInFlight(int flightId)
        {
            var passengers = Manager.FlightRepository.GetPassengersInFlight(flightId);
            return _mapper.Map<List<PostPassengerDto>>(passengers);
        }
        public List<Flight> GetFlightsByDestination(string destination)
        {
            return Manager.FlightRepository.GetFlightsByDestination(destination);
        }

        public List<Flight> GetFlightsByPilotId(int pilotId)
        {
            return Manager.FlightRepository.GetFlightsByPilotId(pilotId);
        }

    }
}
