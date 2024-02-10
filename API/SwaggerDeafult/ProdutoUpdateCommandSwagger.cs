using Application.Interface.Repository;
using Bogus;
using Infra.Repository;
using Swashbuckle.AspNetCore.Filters;

namespace Application.Command.DefaultValue;

public class ProdutoUpdateCommandSwagger: IExamplesProvider<ProdutoUpdateCommand>
{
    public ProdutoUpdateCommand GetExamples()
    {
        return new Faker<ProdutoUpdateCommand>()
            .RuleFor(x => x.Id, x => 1)
            .RuleFor(x => x.Descricao, x => x.Commerce.ProductDescription())
            .RuleFor(x => x.Valor, x => x.Finance.Amount(1,30,2));
    }
}