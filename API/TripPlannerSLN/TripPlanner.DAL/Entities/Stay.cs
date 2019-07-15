using System;
using System.Collections.Generic;

namespace TripPlanner.DAL.Entities
{
    public partial class Stay
    {
        public Stay()
        {
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
