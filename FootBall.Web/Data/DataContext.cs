using FootBall.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootBall.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ClubEntity> Clubs { get; set; }
    }
}
