using Application.Attribute;
using Application.Entity;
using Application.Interface.Repository;
using Infra.Repository.Base;

namespace Infra.Repository;

[Inject]
public class ItemRepository: BaseRepository<Item>, IItemRepository
{
    public ItemRepository(Context ctx) : base(ctx)
    {
    }
}