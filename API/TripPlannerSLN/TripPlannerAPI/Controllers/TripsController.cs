using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.DAL.Entities;
using TripPlanner.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TripPlannerAPI.DTOs;
using Microsoft.AspNetCore.JsonPatch;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripPlannerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]   
    public class TripsController : Controller
    {
        private TripPlannerDBContext _context;
        private readonly IMapper _mapper;
        public TripsController(TripPlannerDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public ActionResult<TripDTO> Get(int id)
        {
            var trip = _context.Trips.Include(p => p.Stay).Include(x => x.Addresses).Include(x => x.WebLinks).FirstOrDefault(t => t.Id == id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TripDTO>(trip));
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<TripDTO> Post([FromBody]TripDTO trip)
        {
            if (trip.Id == 0 && !string.IsNullOrEmpty(trip.Name))
            {
                var tripToSave = _mapper.Map<Trip>(trip);
                _context.Trips.Add(tripToSave);
                _context.SaveChanges();
                return Ok(_mapper.Map<TripDTO>(tripToSave));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<TripDTO> Put(int id, [FromBody]TripDTO tripDto)
        {
            var tripToUpdate = _context.Trips.FirstOrDefault(x => x.Id == id);
            if (tripToUpdate == null)
                return NotFound();
            else
            {
                _mapper.Map(tripDto, tripToUpdate);
                _context.SaveChanges();
                return Ok(_mapper.Map<TripDTO>(tripToUpdate));
            }
        }


        [HttpPatch("update/{id}")]
        public ActionResult<TripDTO> Patch(int id, [FromBody]JsonPatchDocument<TripDTO> tripPatchObj)
        {
            var tripToUpdate = _context.Trips.FirstOrDefault(x => x.Id == id);
            if (tripToUpdate != null)
            {
                var tripToUpdateDTO = _mapper.Map<TripDTO>(tripToUpdate);
                tripPatchObj.ApplyTo(tripToUpdateDTO);

                tripToUpdate = _mapper.Map(tripToUpdateDTO, tripToUpdate);
                //_context.Trips.Attach(tripToUpdate);
                _context.SaveChanges();

                return Ok(_mapper.Map<TripDTO>(_context.Trips.FirstOrDefault(x => x.Id == id)));
            }
            else
            {
                return NotFound();
            }
        }
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
