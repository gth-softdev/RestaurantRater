using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDBContext _context = new RestaurantDBContext();
        // Create (POST)
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (model is null)
            {
                return BadRequest("your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();
                return Ok("You did it");
            }
            return BadRequest(ModelState);

        }
        // Read (GET)
        // Get by ID
        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id); 

            if (restaurant != null)
            {
                return Ok(restaurant);

            }
            return NotFound();
        }
        // Get all

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        // Update (PUT)

        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant updateRestaurant)
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);
                if (restaurant != null)
                {
                    restaurant.Name = updateRestaurant.Name;
                    await _context.SaveChangesAsync();
                    return Ok();

                }
                return NotFound();
            }
            return BadRequest(ModelState);

        }

        //Delete (DELETE)

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById(int id)
        {
            Restaurant entity = await _context.Restaurants.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.Restaurants.Remove(entity);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The restaurant was deleted");
            }
            return InternalServerError();
        }

    }
}
