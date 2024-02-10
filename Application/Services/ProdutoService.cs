using Application.Attribute;
using Application.Command;
using Application.DTO;
using Application.Entity;
using Application.Interface.Repository;
using Application.Util;

namespace Application.Services;

[Inject]
public class ProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<GetAllProdutoDto>> Listar()
    {
        var list = await _produtoRepository.GetAll();
        return list.ToList().ToMap<GetAllProdutoDto>();
    }
    
    public async Task<CreateProdutoDto> Add(ProdutoInsertCommand command)
    {
        var entity = command.ToMap<Produto>();
        await _produtoRepository.Add(entity);
        return entity.ToMap<CreateProdutoDto>();
    }
    
    public async Task  Alt(ProdutoUpdateCommand command)
    {
        var entity = await _produtoRepository.Get(x => x.Id == command.Id);
        
         entity = command.ToMap(entity);
         await _produtoRepository.Alt(entity);
    }
    
    
}