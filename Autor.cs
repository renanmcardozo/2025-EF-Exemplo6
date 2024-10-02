using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Exemplo6;

public class Autor
{
    public int AutorID { get; set; }
    public string Nome { get; set; }
    public DateOnly? DataNascimento { get; set; }
}

public class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.HasIndex(p => p.Nome);
        builder.Property(p => p.Nome).HasMaxLength(80).IsRequired();
    }
}