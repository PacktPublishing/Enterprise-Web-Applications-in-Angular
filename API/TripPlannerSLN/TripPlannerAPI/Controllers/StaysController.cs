using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.DAL.Entities;
using TripPlanner.DAL.Models;
using TripPlannerAPI.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripPlannerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class StaysController : Controller
    {
        private TripPlannerDBContext _context;
        private readonly IMapper _mapper;
        public StaysController(TripPlannerDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<StayDTO> Get()
        {
            return _context.Stays.Select(x => _mapper.Map<StayDTO>(x)).ToList();
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost]
        public ActionResult<StayDTO> Post([FromBody]StayDTO value)
        {
            if (value != null && !string.IsNullOrEmpty(value.Name))
            {
                var stay = _mapper.Map<Stay>(value);
                _context.Stays.Add(stay);
                _context.SaveChanges();
                return Ok(_mapper.Map<StayDTO>(stay));
            }
            else
            {
                return BadRequest();
            }
                
        }

        [HttpPut("{id}")]
        public ActionResult<StayDTO> Put(int id, [FromBody]StayDTO stayDto)
        {
            var stayToUpdate = _context.Stays.FirstOrDefault(x => x.Id == id);
            if (stayToUpdate == null)
                return NotFound();
            else
            {
                _mapper.Map(stayDto, stayToUpdate);
                _context.SaveChanges();
                return Ok(_mapper.Map<StayDTO>(stayToUpdate));
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
