using Microsoft.EntityFrameworkCore;
using Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Models;

namespace Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Data
{
    public class PostDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired();

            // Configure any other entity mappings and relationships here

            base.OnModelCreating(modelBuilder);
        }
    }
}
