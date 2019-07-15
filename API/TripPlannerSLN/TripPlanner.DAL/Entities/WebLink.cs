using System;
using System.Collections.Generic;

namespace TripPlanner.DAL.Entities
{
    public partial class WebLink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? TripId { get; set; }

        public Trip Trip { get; set; }
    }
}
