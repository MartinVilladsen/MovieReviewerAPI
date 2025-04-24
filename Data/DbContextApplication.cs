using imdbRanking.Models;
using Microsoft.EntityFrameworkCore;

namespace imdbRanking.Data
{
    public class DbContextApplication : DbContext
    {
        public DbContextApplication(DbContextOptions<DbContextApplication> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
