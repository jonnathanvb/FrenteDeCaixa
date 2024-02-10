using Application.Attribute;
using Bogus;
using Swashbuckle.AspNetCore.Filters;

namespace Application.Command.DefaultValue;


public class ProdutoInsertCommandSwagger :IExamplesProvider<ProdutoInsertCommand>
{
    public ProdutoInsertCommand GetExamples()
    {
        return new Faker<ProdutoInsertCommand>()
            .RuleFor(x => x.Nome, x => x.Commerce.ProductName())
            .RuleFor(x => x.Descricao, x => x.Commerce.ProductDescription())
            .RuleFor(x => x.Valor, x => x.Finance.Amount(1,30,2))
            .RuleFor(x => x.QuantidadeEmEstoque, x => x.Random.Int(10, 999));
    }
}