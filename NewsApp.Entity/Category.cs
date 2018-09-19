using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Entity
{
    public class Category:IEntityBase
    {
        public long CategoryId { get; set; }
        public Guid KeyId { get; set; }
        public string CategoryName { get; set; }
        public bool PlayFully { get; set; }
        public DateTime CreatedDate { get; set; } // CreatedDate
        public long? CreatedBy { get; set; } // CreatedBy
        public long? DeletedBy { get; set; } // DeletedBy
        public DateTime? DeletedDate { get; set; } // DeletedDate
        public bool IsDeleted { get; set; } // IsDeleted
    }
}
