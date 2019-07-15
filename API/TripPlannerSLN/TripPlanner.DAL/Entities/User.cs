using System;
using System.Collections.Generic;

namespace TripPlanner.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
