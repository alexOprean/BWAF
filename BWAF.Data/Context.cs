namespace BWAF.Data
{
    using BWAF.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class Context: DbContext
    {
        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Entity> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        }
    }
}
