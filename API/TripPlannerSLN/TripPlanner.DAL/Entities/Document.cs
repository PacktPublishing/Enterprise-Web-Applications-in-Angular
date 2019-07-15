using System;
using System.Collections.Generic;

namespace TripPlanner.DAL.Entities
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string IsPublic { get; set; }
        public string DocumentType { get; set; }
        public int? TripId { get; set; }

        public Trip Trip { get; set; }
    }
}
