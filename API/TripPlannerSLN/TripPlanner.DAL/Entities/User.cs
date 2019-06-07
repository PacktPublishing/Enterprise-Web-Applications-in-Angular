using System;
using System.Collections.Generic;
using System.Text;

namespace TripPlanner.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
