using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using boilerplate.web.Models;

namespace boilerplate.web.Data
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<MUser> Users { get; set; }
        public virtual DbSet<MRoles> Roles { get; set; }
        public virtual DbSet<MPermissions> MPermissions { get; set; }
        public virtual DbSet<RolePermissons> RolePermissons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
