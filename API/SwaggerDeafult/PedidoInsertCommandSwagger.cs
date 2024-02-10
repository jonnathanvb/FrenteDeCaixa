using Bogus;
using Swashbuckle.AspNetCore.Filters;

namespace Application.Command.DefaultValue;

public class PedidoInsertCommandSwagger :IExamplesProvider<PedidoInsertCommand>
{
    public PedidoInsertCommand GetExamples()
    {
        var faker = new Faker<PedidoInsertCommand>()
            .RuleFor(p => p.Nome, f => f.Name.FirstName())
            .RuleFor(p => p.Items, f => GetItem(f.Random.Int(10,20)).ToList() );

        return faker.Generate();
    }

    private IEnumerable<ItemInsertCommand> GetItem(int qtd)
    {
        for (int i = 0; i < qtd; i++)
        {
            yield return new Faker<ItemInsertCommand>()
                .RuleFor(x => x.Valor, x => x.Finance.Amount(1, 10))
                .RuleFor(x => x.Quantidade, x => x.Finance.Amount(1, 10, 0))
                .RuleFor(x => x.ProdutoId, x => x.Random.Int(1,10)).Generate();
        }
    }
}