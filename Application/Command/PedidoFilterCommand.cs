namespace Application.Command;

public class PedidoFilterCommand
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string Nome { get; set; } = "";
}