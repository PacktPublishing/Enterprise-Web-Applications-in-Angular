using System;
using System.Collections.Generic;

namespace TripPlanner.DAL.Entities
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
