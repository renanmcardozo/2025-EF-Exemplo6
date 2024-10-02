using Microsoft.EntityFrameworkCore;

namespace EF.Exemplo6;

public class AplicacaoDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(@"Host=192.168.56.101;" +
                                 "Username=biblioteca;" +
                                 "Password=123456;" +
                                 "Database=biblioteca;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new LivroConfiguration());
        modelBuilder.ApplyConfiguration(new AutorConfiguration());
    }
}