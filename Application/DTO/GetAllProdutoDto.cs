namespace Application.DTO;

public class GetAllProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; } = decimal.Zero;
}