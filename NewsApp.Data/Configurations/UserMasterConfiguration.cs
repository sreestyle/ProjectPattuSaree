using PattuSaree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Configurations
{
    public class UserMasterConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserMaster>
    {
        public UserMasterConfiguration()
           : this("dbo")
        {
        }
        public UserMasterConfiguration(string schema)
        {
            ToTable("UserMaster", schema);
            HasKey(x => x.UserMasterId);

            Property(x => x.UserMasterId).HasColumnName(@"UserMasterId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);
            Property(x => x.Username).HasColumnName(@"Username").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40);
            Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.LocationId).HasColumnName(@"LocationId").HasColumnType("bigint").IsOptional();
            Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.SendEmailMessages).HasColumnName(@"SendEmailMessages").HasColumnType("bit").IsOptional();
            Property(x => x.CellPhone).HasColumnName(@"CellPhone").HasColumnType("nvarchar").IsOptional().HasMaxLength(20);
            Property(x => x.SendSmSMessages).HasColumnName(@"SendSmSMessages").HasColumnType("bit").IsOptional();
            Property(x => x.HashedPassword).HasColumnName(@"HashedPassword").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Salt).HasColumnName(@"Salt").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Token).HasColumnName(@"Token").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.TokenExpiryDate).HasColumnName(@"TokenExpiryDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsLocked).HasColumnName(@"IsLocked").HasColumnType("bit").IsRequired();
            Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedBy).HasColumnName(@"DeletedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedDate).HasColumnName(@"DeletedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
        }
    }
}
