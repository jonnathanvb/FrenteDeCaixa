

namespace Application.Command;

public class PedidoInsertCommand
{
    public string Nome { get; set; }
    
    public IList<ItemInsertCommand> Items { get; set; }
}

public class ItemInsertCommand
{
    public int ProdutoId { get; set; }
    public decimal Valor { get; set; }
    public decimal Quantidade { get; set; }
    
}