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
            var tripCount = context.Trips.ToList().Count();
            if (tripCount == 0)
            {
                Trip defaultTrip = new Trip {
                    Name = "Road Trip to East Coast",
                    Detail = "Road trip covering Charlotte to Orlando",
                    StartDate = DateTime.Now.AddMonths(1),
                    CreatedById = 1
                };
                context.Trips.Add(defaultTrip);
                context.SaveChanges();
            }
        }

        // GET: api/<controller>
       
        [HttpGet()]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            var allTripsForUser = _context.Trips;
            return Ok(allTripsForUser);
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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
