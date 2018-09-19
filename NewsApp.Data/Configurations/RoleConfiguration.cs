using PattuSaree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Configurations
{
    public class RoleConfiguration:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
            : this("dbo")
        {
        }

        public RoleConfiguration(string schema)
        {
            ToTable("Role", schema);
            HasKey(x => x.RoleId);

            Property(x => x.RoleId).HasColumnName(@"RoleId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);
            Property(x => x.RoleName).HasColumnName(@"RoleName").HasColumnType("nvarchar").IsRequired().HasMaxLength(500);
            Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedBy).HasColumnName(@"DeletedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedDate).HasColumnName(@"DeletedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            Property(x => x.Group).HasColumnName(@"Group").HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
            HasOptional(a => a.UserMasterCreatedBy).WithMany(b => b.RolesCreatedBy).HasForeignKey(c => c.CreatedBy).WillCascadeOnDelete(false);
            HasOptional(a => a.UserMasterDeletedBy).WithMany(b => b.RolesDeletedBy).HasForeignKey(c => c.DeletedBy).WillCascadeOnDelete(false);
        }
    }
}
