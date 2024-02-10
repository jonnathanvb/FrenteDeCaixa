using Application.Entity;
using Infra.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class Context: DbContext
{
    public override void Dispose()
    {
        base.Dispose();
    }

    public Context(DbContextOptions<Context> option) : base(option) 
    {
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProdutoConfigurationEntity());
        modelBuilder.ApplyConfiguration(new PedidoConfigurationEntity());
        modelBuilder.ApplyConfiguration(new ItemConfigurationEntity());
    }
}