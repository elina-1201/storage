using Microsoft.AspNetCore.Mvc;
using SkladisteAngular.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkladisteAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelivererController : ControllerBase
    {
        SkladisteContext db = new SkladisteContext();

        // GET: api/<DelivererController>
        [HttpGet]
        public IActionResult GetAllDeliverers()
        {
            List<Deliverer> deliverersList = db.Deliverers.OrderByDescending(deliverer => deliverer.DelivererId).ToList();
            if (deliverersList.Count > 0)
            {
                return Ok(deliverersList);
            }
            else
            {
                return BadRequest("There was a problem fetching the data.");
            }
        }

        // GET api/<DelivererController>/5
        [HttpGet("{id}")]
        public IActionResult GetDelivererById(int id)
        {
            Deliverer? deliverer = db.Deliverers.Where(r => r.DelivererId == id).FirstOrDefault();
            if (deliverer == null)
            {
                return NotFound($"The deliverer with ID = {id} could not be found");
            }
            else
            {
                return Ok(deliverer);
            }
        }

        // POST api/<DelivererController>
        [HttpPost]
        public IActionResult PostDeliverer([FromBody] Deliverer data)
        {
            db.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        // PUT api/<DelivererController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateDeliverer(int id, [FromBody] Deliverer newDeliverer)
        {
            Deliverer? originalDeliverer = db.Deliverers.Where(r => r.DelivererId == id).FirstOrDefault();
            originalDeliverer.Name = newDeliverer.Name;
            originalDeliverer.ContactPhone = newDeliverer.ContactPhone;
            originalDeliverer.ContactMail = newDeliverer.ContactMail;
            originalDeliverer.Address = newDeliverer.Address;

            db.SaveChanges();

            return Ok();
        }

        // DELETE api/<DelivererController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDeliverer(int id)
        {
            Deliverer? delivererToDelete = db.Deliverers.Where(r => r.DelivererId == id).FirstOrDefault();
            //select * from  where....
            if (delivererToDelete == null)
            {
                return NotFound($"The deliverer with ID = {id} could not be found");
            }
            else
            {
                db.Remove(delivererToDelete);
                db.SaveChanges();
            }
            return Ok(delivererToDelete);
        }
    }
}
