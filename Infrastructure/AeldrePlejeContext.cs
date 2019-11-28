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
            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Shift>().HasKey(s => s.Id);
            modelBuilder.Entity<Route>().HasKey(r => r.Id);
            modelBuilder.Entity<PendingShift>().HasKey(p => p.Id);
            modelBuilder.Entity<UserPendingShift>().HasKey(up => new {up.PendingShiftId, up.UserId});
            modelBuilder.Entity<User>().HasOne(u => u.Group).WithMany(g => g.Users);
            modelBuilder.Entity<User>().HasMany(u => u.Shifts).WithOne(s => s.User);
            modelBuilder.Entity<Shift>().HasOne(s => s.Route).WithOne(r => r.Shift);
            modelBuilder.Entity<Shift>().HasOne(s => s.PShift).WithOne(p => p.Shift);
            modelBuilder.Entity<UserPendingShift>().HasOne(up => up.User)
                .WithMany(u => u.PShifts)
                .HasForeignKey(up => up.UserId);
            modelBuilder.Entity<UserPendingShift>().HasOne(up => up.PendingShift)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.PendingShiftId);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<PendingShift> PendingShifts { get; set; }
    }
}
