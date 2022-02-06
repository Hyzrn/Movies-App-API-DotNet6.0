using Microsoft.EntityFrameworkCore;
using MoviesApp.API.Entities;

namespace MoviesApp.API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
    }
}
