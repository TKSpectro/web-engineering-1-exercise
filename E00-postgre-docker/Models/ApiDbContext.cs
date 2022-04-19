using Microsoft.EntityFrameworkCore;
using E00_postgre_docker.Models;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
   : base(options)
    {

    }
    public DbSet<Account> Accounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new AccountMap(modelBuilder.Entity<Account>());
    }
}
