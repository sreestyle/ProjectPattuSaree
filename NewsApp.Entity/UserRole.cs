using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Entity
{
    public class UserRole:IEntityBase
    {
        public long UserRoleId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public long RoleId { get; set; }
        public long UserMasterId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Role Role { get; set; }
        public virtual UserMaster UserMaster { get; set; }
    }
}
