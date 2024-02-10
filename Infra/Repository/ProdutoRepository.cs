using Application.Attribute;
using Application.Entity;
using Application.Interface.Repository;
using Infra.Repository.Base;

namespace Infra.Repository;


[Inject]
public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(Context ctx) : base(ctx)
    {
        
    }

 
}