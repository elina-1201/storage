using Microsoft.AspNetCore.Mvc;
using SkladisteAngular.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkladisteAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        SkladisteContext db = new SkladisteContext();

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            List<Category> categoriesList = db.Categories.OrderByDescending(category => category.CategoryId).ToList();
            if (categoriesList.Count > 0)
            {
                return Ok(categoriesList);
            }
            else
            {
                return BadRequest("There was a problem fetching the data.");
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category? category = db.Categories.Where(r => r.CategoryId == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound($"The category with ID = {id} could not be found");
            }
            else
            {
                return Ok(category);
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult PostCategory([FromBody] Category data)
        {
            db.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category newCategory)
        {
            Category? originalCategory = db.Categories.Where(r => r.CategoryId == id).FirstOrDefault();
            originalCategory.Name = newCategory.Name;
            db.SaveChanges();

            return Ok();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category? categoryToDelete = db.Categories.Where(r => r.CategoryId == id).FirstOrDefault();
            if (categoryToDelete == null)
            {
                return NotFound($"The category with ID = {id} could not be found");
            }
            else
            {
                db.Remove(categoryToDelete);
                db.SaveChanges();
            }
            return Ok(categoryToDelete);
        }
    }
}
