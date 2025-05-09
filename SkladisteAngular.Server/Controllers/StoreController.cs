using Microsoft.AspNetCore.Mvc;
using SkladisteAngular.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkladisteAngular.ServerControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        SkladisteContext db = new SkladisteContext();

        // GET: api/<StoreController>
        [HttpGet]
        public IActionResult GetAllStores()
        {
            List<Store> storesList = db.Stores.OrderByDescending(store => store.StoreId).ToList();
            if (storesList.Count > 0)
            {
                return Ok(storesList);
            }
            else
            {
                return BadRequest("There was a problem fetching the data.");
            }
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public IActionResult GetStoreById(int id)
        {
            Store? store = db.Stores.Where(r => r.StoreId == id).FirstOrDefault();
            if(store == null)
            {
                return NotFound($"The store with ID = {id} could not be found");
            }
            else
            {
                return Ok(store);
            }
        }

        // POST api/<StoreController>
        [HttpPost]
        public IActionResult PostStore([FromBody] Store data)
        {
            db.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateStore(int id, [FromBody] Store newStore)
        {
            Store? originalStore = db.Stores.Where(r => r.StoreId == id).FirstOrDefault();
            originalStore.Name = newStore.Name;
            originalStore.Location = newStore.Location;
            db.SaveChanges();

            return Ok();
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            Store? storeToDelete = db.Stores.Where(r => r.StoreId == id).FirstOrDefault();
            //select * from  where....
            if (storeToDelete == null)
            { 
                return NotFound($"The store with ID = {id} could not be found"); 
            }
            else
            {
                db.Remove(storeToDelete);
                db.SaveChanges();
            }
            return Ok(storeToDelete);
        }
    }
}
