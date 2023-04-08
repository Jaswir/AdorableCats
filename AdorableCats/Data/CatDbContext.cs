using AdorableCats.Models;
using Microsoft.EntityFrameworkCore;

namespace AdorableCats.Data
{
    public class CatDbContext: DbContext
    {

        public CatDbContext(DbContextOptions<CatDbContext> options)
            : base(options)
        {
        }

        public DbSet<CatImage> Cat_Images { get; set; }

    }
}
