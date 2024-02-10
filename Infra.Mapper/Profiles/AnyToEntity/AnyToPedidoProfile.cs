using Application.Command;
using Application.Entity;
using AutoMapper;

namespace Infra.Mapper.Profiles.AnyToEntity;

public class AnyToPedidoProfile : Profile
{
    public AnyToPedidoProfile()
    {
        //--------------------------------------//
        CreateMap<PedidoInsertCommand, Pedido>()
            .ForMember(x => x.Nome, y => y.MapFrom(z => z.Nome))
            .ForMember(x => x.Items, y => y.MapFrom(z => z.Items));

        //--------------------------------------//
        CreateMap<ItemInsertCommand, Item>()
            .ForMember(x => x.ProdutoId, y => y.MapFrom(z => z.ProdutoId))
            .ForMember(x => x.Quantidade, y => y.MapFrom(z => z.Quantidade))
            .ForMember(x => x.PrecoUnitario, y => y.MapFrom(z => z.Valor));
    }
}