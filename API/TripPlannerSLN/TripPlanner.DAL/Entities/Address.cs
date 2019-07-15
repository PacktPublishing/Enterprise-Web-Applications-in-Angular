using System;
using System.Collections.Generic;

namespace TripPlanner.DAL.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int? TripId { get; set; }

        public Trip Trip { get; set; }
    }
}
