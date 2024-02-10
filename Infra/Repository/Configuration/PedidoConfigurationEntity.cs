using Application.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infra.Repository.Configuration;

public class PedidoConfigurationEntity: IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedido");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Nome).IsRequired();
        
        builder.HasMany(x => x.Items).WithOne(x => x.Pedido).HasForeignKey(x => x.PedidoId);
        builder.Ignore(x => x.Items);
    }
}