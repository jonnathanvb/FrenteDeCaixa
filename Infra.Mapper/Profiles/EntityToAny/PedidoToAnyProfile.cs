using Application.DTO;
using Application.Entity;
using AutoMapper;

namespace Infra.Mapper.Profiles.EntityToAny;

public class PedidoToAnyProfile : Profile
{
    public PedidoToAnyProfile()
    {
        CreateMap<Pedido, PedidoCreateDto>()
            .ForMember(x => x.Nome, y => y.MapFrom(z => z.Nome))
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Total, y => y.MapFrom(z => z.Items.Sum(t => t.PrecoUnitario * t.Quantidade)));
        
        CreateMap<Pedido, PedidoDto>()
            .ForMember(x => x.Nome, y => y.MapFrom(z => z.Nome))
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Total, y => y.MapFrom(z => z.Items.Sum(t => t.PrecoUnitario * t.Quantidade)));
    }
}