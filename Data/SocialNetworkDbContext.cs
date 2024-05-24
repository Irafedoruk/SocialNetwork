using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Data
{
    public class SocialNetworkDbContext : IdentityDbContext<User>
    {
        public SocialNetworkDbContext()
        {

        }
        public SocialNetworkDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Like>().HasOne(i => i.User).WithMany(i => i.Likes).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Photo>().HasOne(p => p.User).WithMany(u => u.Photos).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
        }        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
