using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.DAL.Entities;
using TripPlanner.DAL.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripPlannerAPI.Controllers
{
    [Route("api/[controller]")]   
    public class TripsController : Controller
    {
        private TripPlannerDBContext _context;
        public TripsController(TripPlannerDBContext context)
        {
            _context = context;
           
        }

        // GET: api/<controller>
       
        [HttpGet()]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            var allTripsForUser = _context.Trips;
            return Ok(allTripsForUser);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            var trip = _context.Trips.FirstOrDefault(t => t.Id == id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
