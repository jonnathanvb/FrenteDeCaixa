using Application.Command;
using Application.Entity;
using AutoMapper;

namespace Infra.Mapper.Profiles.AnyToEntity;

public class AnyToProdutoProfile : Profile
{
    public AnyToProdutoProfile()
    {
        //--------------------------------------//
        CreateMap<ProdutoInsertCommand, Produto>()
            .ForMember(x => x.Nome, y => y.MapFrom(z => z.Nome))
            .ForMember(x => x.Preco, y => y.MapFrom(z => z.Valor))
            .ForMember(x => x.Descricao, y => y.MapFrom(z => z.Descricao))
            .ForMember(x => x.SaldoAtual, y => y.MapFrom(z => z.QuantidadeEmEstoque));

        //--------------------------------------//
        CreateMap<ProdutoUpdateCommand, Produto>()
            .ForMember(x => x.Preco, y => y.MapFrom(z => z.Valor))
            .ForMember(x => x.Descricao, y => y.MapFrom(z => z.Descricao));
    }
}