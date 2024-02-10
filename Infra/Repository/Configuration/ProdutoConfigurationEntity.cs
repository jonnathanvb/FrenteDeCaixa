using Application.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infra.Repository.Configuration;

public class ProdutoConfigurationEntity: IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Descricao);
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.SaldoAtual).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Preco).HasColumnType("decimal(18,2)");
        
        builder.HasMany(x => x.Items).WithOne(x => x.Produto).HasForeignKey(x => x.ProdutoId);
    }
}