using Microsoft.AspNetCore.Mvc;
using SkladisteAngular.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkladisteAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStoreController : ControllerBase
    {
        SkladisteContext db = new SkladisteContext();

        // GET: api/<ItemStoreController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ItemStore> itemStore = db.ItemStores.OrderByDescending(ItemStore => ItemStore.Id).ToList();
            if (itemStore.Count > 0)
            {
                return Ok(itemStore);
            }
            else
            {
                return BadRequest("There was a problem fetching the data.");
            }
        }

        // GET api/<ItemStoreController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ItemStore? itemStore = db.ItemStores.Where(r => r.Id == id).FirstOrDefault();
            if (itemStore == null)
            {
                return NotFound($"The item-store with ID = {id} could not be found");
            }
            else
            {
                return Ok(itemStore);
            }
        }

        // POST api/<ItemStoreController>
        [HttpPost]
        public IActionResult Post([FromBody] ItemStore data)
        {
            db.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        // PUT api/<ItemStoreController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ItemStore newItemStore)
        {
            ItemStore? originalItemStore = db.ItemStores.Where(r => r.StoreId == id).FirstOrDefault();
            originalItemStore.ItemId = newItemStore.ItemId;
            originalItemStore.StoreId = newItemStore.StoreId;
            originalItemStore.Quantity = newItemStore.Quantity;

            db.SaveChanges();

            return Ok();
        }

        // DELETE api/<ItemStoreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ItemStore? itemStoreToDelete = db.ItemStores.Where(r => r.Id == id).FirstOrDefault();
            //select * from  where....
            if (itemStoreToDelete == null)
            {
                return NotFound($"The item-store with ID = {id} could not be found");
            }
            else
            {
                db.Remove(itemStoreToDelete);
                db.SaveChanges();
            }
            return Ok(itemStoreToDelete);
        }
    }
}
