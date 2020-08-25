using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
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
        // Get all



        // Update (PUT)

        //Delete (DELETE)

    }
}
