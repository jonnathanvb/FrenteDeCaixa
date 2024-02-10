using Application.Attribute;
using Application.Entity;
using Application.Interface.Repository;
using Infra.Repository.Base;

namespace Infra.Repository;

[Inject]
public class PedidoRepository: BaseRepository<Pedido>, IPedidoRepository
{
    public PedidoRepository(Context ctx) : base(ctx)
    {
        
    }
    
    
}