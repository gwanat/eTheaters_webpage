using eTheaters.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Play>().HasKey(ap => new
            {
                ap.ActorId,
                ap.PlayId
            });

            modelBuilder.Entity<Actor_Play>().HasOne(p => p.Play).WithMany(ap => ap.Actors_Plays).HasForeignKey(p => p.PlayId);
            modelBuilder.Entity<Actor_Play>().HasOne(p => p.Actor).WithMany(ap => ap.Actors_Plays).HasForeignKey(p => p.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Actor_Play> Actors_Plays { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Director> Directors { get; set; }

        //ORDERS
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
    }
}