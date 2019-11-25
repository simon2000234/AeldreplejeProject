using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeldreplejeInfrastructure
{
    public class AeldrePlejeContext : DbContext
    {
        public AeldrePlejeContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<User> Users { get; set; }
    }
}
