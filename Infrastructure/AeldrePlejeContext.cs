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
    }
}
