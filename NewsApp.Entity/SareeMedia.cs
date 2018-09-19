using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Entity
{
    public class SareeMedia : IEntityBase
    {
        public long SareeMediaId { get; set; }
        public Guid KeyId { get; set; }
        public long SareeId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public long Resolution { get; set; }
        public long OrderId { get; set; }
        public bool IsVideo {get; set; }
        public bool IsLive { get; set; }
        public bool IsYouTube { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedDate { get; set; } // CreatedDate
        public long? CreatedBy { get; set; } // CreatedBy
        public long? DeletedBy { get; set; } // DeletedBy
        public DateTime? DeletedDate { get; set; } // DeletedDate
        public bool IsDeleted { get; set; } // IsDeleted

        
    }
}
