using Microsoft.EntityFrameworkCore;

namespace E04RepetitionDatabase.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(new Note[] {
                new Note { Id = Guid.Parse("73c31f76-e39e-4248-9c18-66a08a5c62c9"), Text = "Note 1" },
                new Note { Id = Guid.Parse("73c31f76-e39e-4248-9c18-66a08a5c62d0"), Text = "Note 2" },
                new Note { Id = Guid.Parse("73c31f76-e39e-4248-9c18-66a08a5c62d1"), Text = "Note 2" }
            });
        }
    }
}