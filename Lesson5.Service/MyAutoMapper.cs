using Lesson5.Core.Dto;
using Lesson5.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lesson5.Service
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            //נבצע מיפוי דו צדדי כאשר גם נרצה להכניס במנה כזה וגם להחזיר (POST,GET)
            CreateMap<Passenger, PostPassengerDto>().ReverseMap();
            //מיפוי חד כיווני רק כאשר נשלוף מהדטה ונרצה להחזיר בצורה שונה
            CreateMap<Passenger, PassengerWithFlightsDto>();
            CreateMap<Flight, FlightDto>();
        }


    }
}
