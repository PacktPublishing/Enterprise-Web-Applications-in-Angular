using System;
using System.Collections.Generic;

namespace TripPlanner.DAL.Entities
{
    public partial class Trip
    {
        public Trip()
        {
            Addresses = new HashSet<Address>();
            Documents = new HashSet<Document>();
            WebLinks = new HashSet<WebLink>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StayId { get; set; }
        public int CreatedById { get; set; }
        public Stay Stay { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<WebLink> WebLinks { get; set; }
    }
}
