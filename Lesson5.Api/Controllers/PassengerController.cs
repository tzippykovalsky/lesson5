using Lesson5.Core.Entities;
using Lesson5.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Lesson5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerService _passengerService;

        public PassengerController(PassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        // GET: api/Passenger
        [HttpGet]
        public ActionResult<List<Passenger>> Get()
        {
            try
            {
                var passengers = _passengerService.GetPassengers();
                return Ok(passengers);
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

        // GET: api/Passenger/5
        [HttpGet("{id}")]
        public ActionResult<Passenger?> Get(int id)
        {
            try
            {
                var passenger = _passengerService.GetPassengerById(id);
                if (passenger == null)
                    return NotFound($"Passenger with ID {id} not found.");

                return Ok(passenger);
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

        // POST: api/Passenger
        [HttpPost]
        public IActionResult Post([FromBody] Passenger passenger)
        {
            try
            {
                _passengerService.AddPassenger(passenger);
                return NoContent(); // 204 - Created with no content
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

        // PUT: api/Passenger/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Passenger passenger)
        {
            try
            {
                _passengerService.UpdatePassenger(passenger, id);
                return NoContent(); // 204 - update succeeded, no content returned
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Passenger/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _passengerService.RemovePassenger(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
