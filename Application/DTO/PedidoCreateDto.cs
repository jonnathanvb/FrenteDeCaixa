namespace Application.DTO;

public class PedidoCreateDto
{
    public string? Nome { get; set; }
    public int Id { get; set; }
    public decimal Total { get; set; }
}