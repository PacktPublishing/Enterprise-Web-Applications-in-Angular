using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlannerAPI.DTOs
{
    public class LoggedinAppUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public string Token { get; set; }
        public bool IsNewPassword { get; set; }

        public DateTime CurrentTokenExpiry { get; set; }
        
    }
}
