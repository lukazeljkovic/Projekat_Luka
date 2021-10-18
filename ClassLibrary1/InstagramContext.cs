using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;

namespace ClassLibrary1
{
    public class InstagramContext : DbContext
    {
        public InstagramContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<LikesPosts> LikesPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LikesPosts>().HasKey(l =>new { l.UserId, l.PostId });

            modelBuilder.Entity<LikesPosts>()
            .HasOne(pl => pl.Post)
            .WithMany(p => p.LikesPosts)
            .HasForeignKey(pl => pl.PostId);
            
            modelBuilder.Entity<LikesPosts>()
                .HasOne(pl => pl.User)
                .WithMany(u => u.LikesPosts)
                .HasForeignKey(pl => pl.UserId);
        }

    }
}
