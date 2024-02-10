using Application.DTO;
using Application.Entity;
using AutoMapper;

namespace Infra.Mapper.Profiles.EntityToAny;

public class ProdutoToAnyProfile : Profile
{
    public ProdutoToAnyProfile()
    {
        CreateMap<Produto, GetAllProdutoDto>()
            .ForMember(x => x.Nome, y => y.MapFrom(z => z.Nome))
            .ForMember(x => x.Valor, y => y.MapFrom(z => z.Preco));

        CreateMap<Produto, CreateProdutoDto>()
            .ForMember(x => x.Nome, y => y.MapFrom(z => z.Nome))
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
    }
}