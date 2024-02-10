using Application.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infra.Repository.Configuration;

public class ItemConfigurationEntity: IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Item");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
       
        builder.Property(x => x.ProdutoId);
        builder.Property(x => x.PedidoId);
        builder.Property(x => x.Quantidade).HasColumnType("decimal(18,2)");
        builder.Property(x => x.PrecoUnitario).HasColumnType("decimal(18,2)");
        
        builder.HasOne(x => x.Pedido).WithMany(x => x.Items).HasForeignKey(x => x.PedidoId);
        builder.HasOne(x => x.Produto).WithMany(x => x.Items).HasForeignKey(x => x.ProdutoId);

        builder.Ignore(x => x.Pedido);
    }
}