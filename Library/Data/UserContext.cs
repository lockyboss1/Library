using System;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Data
{
    public class UserContext : DbContext
    {
        public DbSet<Users> User { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
        }
    }
}
