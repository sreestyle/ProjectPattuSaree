using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Entity
{
    public interface IEntityBase
    {
         Guid KeyId { get; set; }
         DateTime CreatedDate { get; set; }
         long? CreatedBy { get; set; }
         DateTime? DeletedDate { get; set; }
         long? DeletedBy { get; set; }
         bool IsDeleted { get; set; }
    }
}
