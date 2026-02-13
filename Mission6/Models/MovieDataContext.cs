using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6.Models
{
    public class MovieDataContext : DbContext
    {
        public MovieDataContext(DbContextOptions<MovieDataContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
