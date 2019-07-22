using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlannerAPI.DTOs
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string IsPublic { get; set; }
        public string DocumentType { get; set; }
    }
}
