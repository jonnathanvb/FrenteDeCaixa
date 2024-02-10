using System.ComponentModel;

namespace Application.Command;

public class ProdutoInsertCommand
{

    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal QuantidadeEmEstoque { get; set; } = decimal.Zero;
    public decimal Valor { get; set; } = decimal.Zero;
}