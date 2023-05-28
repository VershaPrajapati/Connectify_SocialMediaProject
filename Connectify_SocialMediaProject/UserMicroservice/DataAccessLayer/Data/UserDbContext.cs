using Microsoft.EntityFrameworkCore;
using UserMicroservice.DataAccessLayer.Models;

namespace UserMicroservice.DataAccessLayer.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Configure any other entity mappings and relationships here

            base.OnModelCreating(modelBuilder);
        }
    }
}
