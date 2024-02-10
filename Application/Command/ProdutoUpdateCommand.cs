using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Application.Command;

public class ProdutoUpdateCommand
{
    [JsonIgnore]
    public int Id { get; set; }
    
    [DefaultValue("Coca-Cola é um refrigerante carbonatado. Gelado.")]
    public string Descricao { get; set; } = string.Empty;
    
    [DefaultValue(5.50)]
    public decimal Valor { get; set; } = decimal.Zero;
}