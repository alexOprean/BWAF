namespace BWAF_DAL
{
    using BWAF_DAL.Models;
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
