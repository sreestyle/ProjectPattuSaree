using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Entity
{
    public class UserMaster:IEntityBase
    {
        public long UserMasterId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? LocationId { get; set; }
        public string Email { get; set; }
        public bool? SendEmailMessages { get; set; }
        public string CellPhone { get; set; }
        public bool? SendSmSMessages { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiryDate { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Role> RolesCreatedBy { get; set; } = new List<Role>();
        public virtual ICollection<Role> RolesDeletedBy { get; set; } = new List<Role>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
