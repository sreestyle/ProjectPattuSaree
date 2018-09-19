using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Entity
{
    public class Role:IEntityBase
    {
        public long RoleId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public string RoleName { get; set; }
        public string Group { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public virtual UserMaster UserMasterCreatedBy { get; set; }
        public virtual UserMaster UserMasterDeletedBy { get; set; }
    }
}
