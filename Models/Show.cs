using System;
using System.Collections.Generic;

namespace Stagedoor.Models {
    public class Show {
        public int Id { get; set; }
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Performance> Performances { get; set; } = new List<Performance>();
    }
}