using Microsoft.EntityFrameworkCore;

namespace E06RepetitionRest.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>().HasData(new Module[] {
                new Module { Id = Guid.Parse("73c31f76-e39e-4248-9c18-66a08a5c62c9"), Name = "MC1", Cp = 5, Sws = 8 },
                new Module { Id = Guid.Parse("73c31f76-e39e-4248-9c18-66a08a5c62d0"), Name = "WE1", Cp = 5, Sws = 8 },
                new Module { Id = Guid.Parse("73c31f76-e39e-4248-9c18-66a08a5c62d1"), Name = "VRAR", Cp = 5, Sws = 8}
            });
        }
    }
}