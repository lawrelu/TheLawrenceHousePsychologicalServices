using System;
using System.Collections.Generic;

namespace Stagedoor.Models {
    public class Organisation {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CloudProvider { get; set; } // "OneDrive" or "GoogleDrive"
        public string CloudAccessToken { get; set; }
        public string CloudRefreshToken { get; set; }
        public DateTime? LastCloudSync { get; set; }
        public ICollection<Show> Shows { get; set; } = new List<Show>();
    }
}