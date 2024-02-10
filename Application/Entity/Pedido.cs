namespace Application.Entity;

public class Pedido
{
    public int Id { get; set; } = 0;
    public string Nome { get; set; } = String.Empty;



    public ICollection<Item>? Items { get; set; }

}