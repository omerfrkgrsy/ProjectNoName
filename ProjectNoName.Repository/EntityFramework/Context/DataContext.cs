
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
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Comment>()
               .HasOne(p => p.Post)
               .WithMany(b => b.Comments)
               .HasForeignKey(p => p.PostId);

            modelBuilder.Entity<Comment>()
               .HasOne(p => p.User)
               .WithMany(b => b.Comments)
               .HasForeignKey(p => p.UserId);


        }
    }
}
