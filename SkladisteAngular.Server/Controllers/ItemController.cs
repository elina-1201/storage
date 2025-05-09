using Microsoft.AspNetCore.Mvc;
using SkladisteAngular.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkladisteAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        SkladisteContext db = new SkladisteContext();

        // GET: api/<ItemController>
        [HttpGet]
        public IActionResult GetAllItems()
        {
            List<Item> itemsList = db.Items.OrderByDescending(item => item.ItemId).ToList();
            if (itemsList.Count > 0)
            {
                return Ok(itemsList);
            }
            else
            {
                return BadRequest("There was a problem fetching the data.");
            }
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            Item? item = db.Items.Where(r => r.ItemId== id).FirstOrDefault();
            if (item == null)
            {
                return NotFound($"The item with ID = {id} could not be found");
            }
            else
            {
                return Ok(item);
            }
        }

        // POST api/<ItemController>
        [HttpPost]
        public IActionResult PostItem([FromBody] Item data)
        {
            db.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            Item? itemToDelete = db.Items.Where(r => r.ItemId == id).FirstOrDefault();
            //select * from  where....
            if (itemToDelete == null)
            {
                return NotFound($"The item with ID = {id} could not be found");
            }
            else
            {
                db.Remove(itemToDelete);
                db.SaveChanges();
            }
            return Ok(itemToDelete);
        }
    }
}
