using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Persistence
{
    public class VegaDBContext : DbContext
    {
        // we want to derive this class from DbContext which is in EntityFrameworkCore namespace.
        public VegaDBContext(DbContextOptions<VegaDBContext> options)
            : base(options)
        {
            // base means pass VegaDBContext to the base class ie VegaDBContext

        }
        public DbSet<Make> Makes { get; set; }
    }
}