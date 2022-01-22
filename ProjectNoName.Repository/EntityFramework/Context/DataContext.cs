
using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<Comment>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasOne(p => p.Post).WithMany(t => t.Comments).HasForeignKey(p => p.PostId);
                b.HasOne(p => p.User).WithMany(t => t.Comments).HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(x => x.Followers);
                b.HasMany(x => x.Followed);
            });

        }
    }
}
