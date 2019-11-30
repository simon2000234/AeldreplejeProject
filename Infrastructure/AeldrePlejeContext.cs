using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeldreplejeInfrastructure
{
    public class AeldrePlejeContext : DbContext
    {
        public AeldrePlejeContext(DbContextOptions<AeldrePlejeContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<PendingShift> PendingShifts { get; set; }
    }
}
