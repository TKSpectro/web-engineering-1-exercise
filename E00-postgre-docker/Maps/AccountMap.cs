using E00_postgre_docker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AccountMap
{
    public AccountMap(EntityTypeBuilder<Account> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("account");

        entityBuilder.Property(x => x.Id).HasColumnName("id");
        entityBuilder.Property(x => x.Name).HasColumnName("name");
        entityBuilder.Property(x => x.Email).HasColumnName("email");
        entityBuilder.Property(x => x.Password).HasColumnName("password");
    }
}
