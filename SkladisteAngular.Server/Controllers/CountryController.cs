using Microsoft.AspNetCore.Mvc;
using SkladisteAngular.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkladisteAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        SkladisteContext db = new SkladisteContext();

        // GET: api/<CountryController>
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            List<Country> countriesList = db.Countries.OrderByDescending(country => country.CountryId).ToList();
            if (countriesList.Count > 0)
            {
                return Ok(countriesList);
            }
            else
            {
                return BadRequest("There was a problem fetching the data.");
            }
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            Country? country = db.Countries.Where(r => r.CountryId== id).FirstOrDefault();
            if (country == null)
            {
                return NotFound($"The country with ID = {id} could not be found");
            }
            else
            {
                return Ok(country);
            }
        }

        // POST api/<CountryController>
        [HttpPost]
        public IActionResult PostCountry([FromBody] Country data)
        {
            db.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] Country newCountry)
        {
            Country? originalCountry = db.Countries.Where(r => r.CountryId == id).FirstOrDefault();
            originalCountry.Name = newCountry.Name;
            originalCountry.Code = newCountry.Code;
            db.SaveChanges();

            return Ok();
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            Country? countryToDelete = db.Countries.Where(r => r.CountryId == id).FirstOrDefault();
            //select * from  where....
            if (countryToDelete == null)
            {
                return NotFound($"The country with ID = {id} could not be found");
            }
            else
            {
                db.Remove(countryToDelete);
                db.SaveChanges();
            }
            return Ok(countryToDelete);
        }
    }
}
