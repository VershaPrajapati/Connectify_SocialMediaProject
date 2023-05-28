using Microsoft.EntityFrameworkCore;
using FollowMicroservice.DataAccessLayer.Models;

namespace FollowMicroservice.DataAccessLayer.Data
{
    public class FollowDbContext : DbContext
    {
        public DbSet<Follow> Follows { get; set; }

        public FollowDbContext(DbContextOptions<FollowDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany()
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Following)
                .WithMany()
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure any other entity mappings and relationships here

            base.OnModelCreating(modelBuilder);
        }
    }
}
