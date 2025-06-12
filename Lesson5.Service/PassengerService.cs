using AutoMapper;
using Lesson5.Core.Dto;
using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Service
{
    public class PassengerService(IMapper mapper, IPassengerRepository passengerRepository)
    {
        private readonly IPassengerRepository _passengerRepository=passengerRepository;
        private readonly IMapper _mapper = mapper;



        public List<PassengerWithFlightsDto> GetPassengers()
        {
            List<Passenger> listToConvert = _passengerRepository.GetAll();

            // שימוש ב־AutoMapper להמרת כל הרשימה
            return _mapper.Map<List<PassengerWithFlightsDto>>(listToConvert);
        }


        public PassengerWithFlightsDto? GetPassengerById(int id)
        {
            return _mapper.Map<PassengerWithFlightsDto>(_passengerRepository.GetById(id));
        }

        public void AddPassenger(PostPassengerDto passengerDto)
        {
            // ולידציה בסיסית
            if (string.IsNullOrWhiteSpace(passengerDto.FullName))
                throw new ArgumentException("Passenger name is required.");

            if (string.IsNullOrWhiteSpace(passengerDto.PassportNumber))
                throw new ArgumentException("Passport number is required.");

            // בדיקה אם קיים נוסע עם אותו מספר דרכון
            var existing = _passengerRepository.GetAll()
                                .FirstOrDefault(p => p.PassportNumber == passengerDto.PassportNumber);
            if (existing != null)
                throw new InvalidOperationException("Passenger with the same passport number already exists.");


            // המרה מ־DTO ל־Entity
            Passenger passenger = _mapper.Map<Passenger>(passengerDto);
            _passengerRepository.Add(passenger);
        }

        public void RemovePassenger(int id)
        {
            var existing = _passengerRepository.GetById(id);
            if (existing == null)
                throw new KeyNotFoundException($"Passenger with ID {id} not found.");

            _passengerRepository.Delete(id);
        }

        public void UpdatePassenger(PostPassengerDto passenger, int id)
        {
            var existing = _passengerRepository.GetById(id);
            if (existing == null)
                throw new KeyNotFoundException($"Passenger with ID {id} not found.");

            // לא ניתן לשנות מספר דרכון
            if (!string.IsNullOrWhiteSpace(passenger.PassportNumber) &&
                passenger.PassportNumber != existing.PassportNumber)
            {
                throw new InvalidOperationException("Cannot change passenger's passport number.");
            }

            // עדכון שדות אם לא ריק
            if (!string.IsNullOrWhiteSpace(passenger.FullName))
                existing.FullName = passenger.FullName;

            // כאן לא נוגעים ב-Flights כדי לשמור על הקשרים הקיימים

            _passengerRepository.Update(existing);
        }
    }
}
