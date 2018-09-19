using PattuSaree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Configurations
{
    public class UserRoleConfiguration:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration():this("dbo"){

        }
        public UserRoleConfiguration(string schema)
        {
            ToTable("UserRole", schema);
            HasKey(x => x.UserRoleId);

            Property(x => x.UserRoleId).HasColumnName(@"UserRoleId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);
            Property(x => x.RoleId).HasColumnName(@"RoleId").HasColumnType("bigint").IsRequired();
            Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedBy).HasColumnName(@"DeletedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedDate).HasColumnName(@"DeletedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            Property(x => x.UserMasterId).HasColumnName(@"UserMasterId").HasColumnType("bigint").IsRequired();


            HasRequired(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(c => c.RoleId).WillCascadeOnDelete(false);
            HasRequired(a => a.UserMaster).WithMany(b => b.UserRoles).HasForeignKey(c => c.UserMasterId).WillCascadeOnDelete(false);
        }
    }
}
