using Lesson5.Core.Dto;
using Lesson5.Core.Entities;
using Lesson5.Service;
using Microsoft.AspNetCore.Mvc;
//I want you to act as a c# developer
//write this class controller
//use the functions from Lesson5.Service project
//and create a controller that will use the functions from the service
//the functions will return ActionResult 
//use try catch to handle exceptions


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson5.Api.Controllers
{
    [Route("api/[controller]")]//הגדרת הניתוב לקונטרולרים בדף זה
    [ApiController]
    public class FlightController : ControllerBase
    {

        private readonly FlightService _flightService;
        public FlightController(FlightService flightService)
        {
            _flightService = flightService;
        }

        // GET: api/<FlightController>
        [HttpGet]
        public ActionResult<List<Flight>> Get()
        {
            try
            {
                //call the service to get the flights
                var flights = _flightService.GetFlights();
                return Ok(flights);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //לא ניתן להריץ את הקוד הבא משום שיהיה 2 endpoints זהים
        //כלומר מבחינת c# זה בסדר אך לא מבחינת הapi

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public ActionResult<Flight?> Get(int id)
        {
            try
            {
                var flight = _flightService.GetFlightById(id);
                if (flight == null)
                    return NotFound($"Flight with id {id} not found.");
                return Ok(flight);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<FlightController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Flight value)
        {
            try
            {
                await _flightService.AddFlight(value);
                // Assuming value.Id is set after add
                return Created($"api/Flight/{value.Id}", value);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Flight value)
        {
            try
            {
                _flightService.UpdateFlight(value, id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _flightService.RemoveFlight(id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Flight/by-destination/{destination}
        [HttpGet("by-destination/{destination}")]
        public ActionResult<List<Flight>> GetFlightsByDestination(string destination)
        {
            try
            {
                var flights = _flightService.GetFlightsByDestination(destination);
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET: api/Flight/by-pilot/{pilotId}
        [HttpGet("by-pilot/{pilotId}")]
        public ActionResult<List<Flight>> GetFlightsByPilotId(int pilotId)
        {
            try
            {
                var flights = _flightService.GetFlightsByPilotId(pilotId);
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET: api/Flight/{flightId}/passengers
        [HttpGet("{flightId}/passengers")]
        public ActionResult<List<PostPassengerDto>> GetPassengersInFlight(int flightId)
        {
            try
            {
                var passengers = _flightService.GetPassengersInFlight(flightId);
                return Ok(passengers);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // POST: api/Flight/{flightId}/add-passenger
        [HttpPost("{flightId}/add-passenger")]
        public IActionResult AddPassengerToFlight(int flightId, [FromBody] Passenger passenger)
        {
            try
            {
                _flightService.AddPassengerToFlight(flightId, passenger);
                return Ok($"Passenger added to flight {flightId}");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // DELETE: api/Flight/{flightId}/remove-passenger/{passengerId}
        [HttpDelete("{flightId}/remove-passenger/{passengerId}")]
        public IActionResult RemovePassengerFromFlight(int flightId, int passengerId)
        {
            try
            {
                _flightService.RemovePassengerFromFlight(flightId, passengerId);
                return Ok($"Passenger {passengerId} removed from flight {flightId}");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        private ActionResult HandleException(Exception ex)
        {
            return ex switch
            {
                ArgumentNullException => NotFound(ex.Message),
                ArgumentException => BadRequest(ex.Message),
                _ => StatusCode(500, "An unexpected error occurred: " + ex.Message)
            };
        }

    }
}
