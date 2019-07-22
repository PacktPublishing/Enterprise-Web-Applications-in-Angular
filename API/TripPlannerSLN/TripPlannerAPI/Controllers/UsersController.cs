using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.DAL.Entities;
using TripPlanner.DAL.Models;
using TripPlannerAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using TripPlanner.Infrastructure.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IEnumerable<User> _users;
        private readonly IConfiguration _configuration;
        private TripPlannerDBContext _context;
        private readonly IMapper _mapper;
        public UsersController(IConfiguration configuration, TripPlannerDBContext context, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;

            _users = context.Users.Include(x => x.UserRoles).Include(x => x.Trips);

        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {            var userList = _users.Select(x => _mapper.Map<UserDTO>(x));
            return Ok(userList.ToList());
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (!string.IsNullOrEmpty(user.Fname) &&
                !string.IsNullOrEmpty(user.Lname) &&
                !string.IsNullOrEmpty(user.Email) &&
                !string.IsNullOrEmpty(user.Pwd))
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest();

            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> Post([FromBody]TripPlannerLoginDTO loginDto)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _context.Users.Include(x => x.UserRoles)
                    .ThenInclude(y => y.Role) 
                    .FirstOrDefaultAsync(x => x.Email == loginDto.Username && x.Pwd == loginDto.Password);

                if (appUser == null)
                {
                    return Unauthorized();
                }

                DateTime expiry = DateTime.UtcNow.AddHours(24);
                LoggedinAppUserDTO loggedInAppUser = new LoggedinAppUserDTO {
                    Name = appUser.Fname + " " + appUser.Lname,
                    Email = appUser.Email,
                    Roles = appUser.UserRoles.Select(x => x.Role).Select(y => y.Name).ToArray()
                };
                loggedInAppUser.CurrentTokenExpiry = expiry;
                var token = GetToken(loggedInAppUser, expiry);

                loggedInAppUser.Token = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(loggedInAppUser);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet("{userId}/Trips")]
        public async Task<ActionResult<Trip>> GetTripsByUser(int userId)
        {
            var user = await _context.Users.
                Include(p => p.Trips)
                    .ThenInclude(t => t.Stay)
                    .Include(t => t.Trips)
                    .ThenInclude(t => t.Addresses)
                .FirstAsync(x => x.Id == userId);
                
            return Ok(user.Trips.Select(x => _mapper.Map<TripDTO>(x)));
        }
        private JwtSecurityToken GetToken(LoggedinAppUserDTO loggedInAppUser, DateTime expiry)
        {
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, loggedInAppUser.Email),
                new Claim(ClaimTypes.Role, "AppUser")
            };
            claims.Concat(loggedInAppUser.Roles.Select(x => new Claim(ClaimTypes.Role, x)));
            var token = new JwtSecurityToken
            (
                issuer: _configuration[WebConfig.TOKEN_ISSUER],
                audience: _configuration[WebConfig.TOKEN_AUDIENCE],
                claims: claims,
                expires: expiry,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[WebConfig.TOKEN_SIGNING_KEY])),
                     SecurityAlgorithms.HmacSha256)
            );

            return token;
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
