

namespace Application.Entity;

public class Produto 
{
    public int Id { get; set; }
    // public string Path { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal SaldoAtual { get; set; } = decimal.Zero;
    public decimal Preco { get; set; } = decimal.Zero;
    
    
    public IEnumerable<Item> Items { get; set; } = new List<Item>();
}