using Application.Attribute;
using Application.Command;
using Application.DTO;
using Application.Entity;
using Application.Interface.Repository;
using Application.Util;

namespace Application.Services;

[Inject]
public class PedidoServices(
    IProdutoRepository produtoRepository,
    IPedidoRepository pedidoRepository,
    IItemRepository itemRepository
)
{
    public async Task<IEnumerable<PedidoDto>> Listar()
    {
        var pedidos = await pedidoRepository.GetAll(null, x => x.Items);
        return pedidos.ToList().ToMap<PedidoDto>();
    }
    
    public async Task<IEnumerable<PedidoDto>> Listar(PedidoFilterCommand command)
    {
        IEnumerable<Pedido> pedidos = new List<Pedido>();
        if (string.IsNullOrEmpty(command.Nome))
        { 
            pedidos = await pedidoRepository.GetAll(command.Page, command.Size,x => x.Nome.Contains(command.Nome), null, x => x.Items);
        }
        else
        {
            pedidos = await pedidoRepository.GetAll(command.Page, command.Size, null, null, x => x.Items);
        }
       
        return pedidos.ToList().ToMap<PedidoDto>();
    }

    public async Task<PedidoCreateDto> Add(PedidoInsertCommand command)
    {

        // Add Pedido
        var pedido = new Pedido()
        {
            Nome = command.Nome , 
            Items = new List<Item>()
        };
        await pedidoRepository.Add(pedido);
        
        // Add item
        var itens = new List<Item>();
        foreach (var obj in command.Items)
        {
            var item = new Item()
            {
                ProdutoId = obj.ProdutoId,
                Quantidade = obj.Quantidade,
                PrecoUnitario = obj.Valor
            };
           await itemRepository.Add(item);
           pedido.Items?.Add(item);
        }
        
        
        return pedido.ToMap<PedidoCreateDto>();
    }
    
}