using FootBall.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootBall.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ClassificationEntity> Classifications { get; set; }

        public DbSet<ClubEntity> Clubs { get; set; }

        public DbSet<GameEntity> Games { get; set; }

        public DbSet<ResultEntity> Results { get; set; }

        public DbSet<SessionEntity> Sessions { get; set; }

        public DbSet<TournamentEntity> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClubEntity>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
