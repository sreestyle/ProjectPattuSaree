using PattuSaree.Data.Configurations;
using PattuSaree.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.DbContext
{
     public class PattuSareeContext: System.Data.Entity.DbContext
     {
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SareeMedia> NewsMedia { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        


        public PattuSareeContext()
            : base("NewsApp")
        {
            Database.SetInitializer<PattuSareeContext>(null);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserMasterConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SareeMediaConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());

        }
    }
}
