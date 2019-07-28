using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlannerAPI.DTOs
{
    public class TripDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StayId { get; set; }
        public int CreatedById { get; set; }
        public StayDTO Stay { get; set; }
        
        public ICollection<AddressDTO> Addresses { get; set; }
        //public ICollection<DocumentDTO> Documents { get; set; }
        public ICollection<WebLinkDTO> WebLinks { get; set; }
    }
}
