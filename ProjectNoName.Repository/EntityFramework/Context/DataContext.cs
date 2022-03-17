
using Microsoft.EntityFrameworkCore;
using ProjectNoName.Entities;
using ProjectNoName.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Repository.EntityFramework.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RelationShip> RelationShips { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasOne(p => p.User).WithMany(t => t.Posts).HasForeignKey(p => p.UserId);
                b.HasMany(j => j.SubPosts).WithOne(j => j.Parent).HasForeignKey(j => j.ParentId);
            });

            modelBuilder.Entity<RelationShip>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasOne(p => p.Follewer).WithMany(t => t.Followers).HasForeignKey(p => p.FollewerId);
                b.HasOne(p => p.Follewed).WithMany(t => t.Followed).HasForeignKey(p => p.FollowedId);
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Like>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasKey(x => x.PostId);
                b.HasOne(p => p.User).WithMany(t => t.Likes).HasForeignKey(p => p.Id);
                b.HasOne(p => p.Post).WithMany(t => t.Likes).HasForeignKey(p => p.PostId);
            });



        }
    }
}
