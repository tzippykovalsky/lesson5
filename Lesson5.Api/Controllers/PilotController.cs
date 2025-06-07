using Lesson5.Core.Entities;
using Lesson5.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private readonly PilotService _pilotService;
        public PilotController(PilotService pilotService)
        {
            _pilotService = pilotService;
        }

        // GET: api/<PilotController>
        [HttpGet]
        public ActionResult<List<Pilot>> Get()
        {
            try
            {
                //call the service to get the pilots
                var pilots = _pilotService.GetPilots();
                //return the pilots
                return Ok(pilots);
            }
            catch (ArgumentNullException ex)
            {
                //return an error message
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                //return an error message
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                //return an error message
                return BadRequest(ex.Message);
            }
        }
        // GET api/<PilotController>/5
        [HttpGet("{id}")]
        public ActionResult<Pilot?> Get(int id)
        {
            //call the service to get the pilot by id
            try
            {
                var pilot = _pilotService.GetPilotById(id);
                //return the pilot
                return Ok(pilot);
            }
            catch (ArgumentNullException ex)
            {
                //return an error message
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                //return an error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                //return an error message
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PilotController>
        [HttpPost]
        public IActionResult Post([FromBody] Pilot value)
        {
            try
            {
                _pilotService.AddPilot(value);
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


        // PUT api/<PilotController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pilot value)
            //TODO
            //חייבים לשלוח בפורמט  של טייס גם במקרה שמעוניינת רק לשנות פריקט אחד
            //לבדוק שכך באמת עושים
        {
            try
            {
                _pilotService.UpdatePilot(value, id);
                return NoContent(); // 204 - עדכון הצליח, אין תוכן להחזיר
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // 404 אם לא נמצא טייס
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // 400 אם יש בעיה בלוגיקה (כמו שינוי ת"ז)
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 400 לשגיאות אחרות
            }
        }

        // DELETE api/<PilotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                //call the service to remove the pilot
                _pilotService.RemovePilot(id);
            }
            catch (ArgumentNullException ex)
            {
                BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
