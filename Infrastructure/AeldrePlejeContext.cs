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
            modelBuilder.Entity<User>().HasOne(u => u.Group)
                .WithMany(g => g.Users).OnDelete(DeleteBehavior.SetNull); 
            modelBuilder.Entity<User>().HasMany(u => u.Shifts)
                .WithOne(s => s.User).OnDelete(DeleteBehavior.SetNull); 
            modelBuilder.Entity<Route>().HasOne(r => r.Shift)
                .WithOne(s => s.Route)
                .HasForeignKey<Shift>(s => s.RouteId).OnDelete(DeleteBehavior.SetNull); 
            modelBuilder.Entity<PendingShift>().HasOne(p => p.Shift)
                .WithOne(s => s.PShift)
                .HasForeignKey<PendingShift>(p => p.ShiftId).OnDelete(DeleteBehavior.SetNull); 
            modelBuilder.Entity<UserPendingShift>().HasOne(up => up.User)
                .WithMany(u => u.PShifts)
                .HasForeignKey(up => up.UserId).OnDelete(DeleteBehavior.SetNull); 
            modelBuilder.Entity<UserPendingShift>().HasOne(up => up.PendingShift)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.PendingShiftId).OnDelete(DeleteBehavior.SetNull); 
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<PendingShift> PendingShifts { get; set; }
    }
}
