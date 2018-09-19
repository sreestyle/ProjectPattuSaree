using PattuSaree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Configurations
{
    public class SareeMediaConfiguration:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SareeMedia>
    {
        public SareeMediaConfiguration() : this("dbo")
        {

        }
        public SareeMediaConfiguration(string schema)
        {
            ToTable("SareeMedia");
            HasKey(x => x.SareeMediaId);

            Property(x => x.SareeMediaId).HasColumnName(@"SareeMediaId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);
            Property(x => x.SareeId).HasColumnName(@"SareeId").HasColumnType("bigint").IsRequired();
            Property(x => x.Url).HasColumnName(@"Url").HasColumnType("nvarchar").IsMaxLength().IsOptional();
            Property(x => x.FileName).HasColumnName(@"FileName").HasColumnType("nvarChar").HasMaxLength(100).IsOptional();
           
            Property(x => x.Resolution).HasColumnType(@"Resolution").HasColumnType("bigint").IsRequired();
            Property(x => x.OrderId).HasColumnName(@"OrderId").HasColumnType("bigint").IsRequired();
            Property(x => x.IsVideo).HasColumnName(@"IsVideo").HasColumnType("bit").IsRequired();
            Property(x => x.IsLive).HasColumnName(@"IsLive").HasColumnType("bit").IsRequired();
            Property(x => x.IsYouTube).HasColumnName(@"IsYouTube").HasColumnType("bit").IsRequired();
            Property(x => x.StartTime).HasColumnName(@"StartDate").HasColumnType("datetime").IsOptional();
            Property(x => x.EndTime).HasColumnName(@"EndTime").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedBy).HasColumnName(@"DeletedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedDate).HasColumnName(@"DeletedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            //HasRequired(x => x.News).WithMany(a=>a.NewsMedia).HasForeignKey(b=>b.NewsId).WillCascadeOnDelete(false);
        }
    }
}
