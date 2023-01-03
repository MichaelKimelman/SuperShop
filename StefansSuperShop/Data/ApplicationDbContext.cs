using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace StefansSuperShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ExtendedUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetails>()
                .HasKey(e => new { e.OrderId, e.ProductId });
            modelBuilder.Entity<Subscriber>()
                .HasMany(left => left.Newsletters)
                .WithMany(right => right.Subscribers)
                .UsingEntity<NewsletterSubscriber>(
                    right => right.HasOne(e => e.Newsletter).WithMany(),
                    left => left.HasOne(e => e.Subscriber).WithMany().HasForeignKey(e => e.SubscriberId),
                    join => join.ToTable("NewsletterSubscribers")
                    );
            modelBuilder.Entity<Newsletter>()
                .HasData(
                    new Newsletter { Id = 1, Title = "Newsletter 1", Message = "This is our first newsletter!" },
                    new Newsletter { Id = 2, Title = "Newsletter 2", Message = "This is our second newsletter!" }
                    );
            modelBuilder.Entity<Subscriber>()
                .HasData(
                    new Subscriber { Id = 1, Email = "sven.svensson@mail.se" },
                    new Subscriber { Id = 2, Email = "karl.karlsson@mail.se" },
                    new Subscriber { Id = 3, Email = "anders.andersson@mail.se" },
                    new Subscriber { Id = 4, Email = "magnus.magnusson@mail.se" },
                    new Subscriber { Id = 5, Email = "johan.johansson@mail.se" },
                    new Subscriber { Id = 6, Email = "mats.matsson@mail.se" }
                    );
            modelBuilder.Entity<NewsletterSubscriber>()
                .HasData( 
                    new { Id = 1, NewsletterId = 1, SubscriberId = 1},
                    new { Id = 2, NewsletterId = 1, SubscriberId = 2},
                    new { Id = 3, NewsletterId = 1, SubscriberId = 3},
                    new { Id = 4, NewsletterId = 1, SubscriberId = 4},
                    new { Id = 5, NewsletterId = 2, SubscriberId = 1},
                    new { Id = 6, NewsletterId = 2, SubscriberId = 2},
                    new { Id = 7, NewsletterId = 2, SubscriberId = 5},
                    new { Id = 8, NewsletterId = 2, SubscriberId = 6}
                    );

        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
    }
}
