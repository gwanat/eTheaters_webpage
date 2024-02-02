using eTheaters.Models;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Data
{
    public class AppDbContext : DbContext
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
    }
}