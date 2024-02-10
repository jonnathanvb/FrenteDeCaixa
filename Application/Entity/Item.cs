namespace Application.Entity;

public class Item
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }
    public decimal Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }


    public Produto? Produto { get; set; } 
    public Pedido? Pedido { get; set; }
}