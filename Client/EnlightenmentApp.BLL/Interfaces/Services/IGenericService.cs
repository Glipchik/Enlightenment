using EnlightenmentApp.BLL.Entities;

namespace EnlightenmentApp.BLL.Interfaces.Services
{
    public interface IGenericService<TItem> where TItem : BaseItem
    {
        public Task<IEnumerable<TItem>> GetItems(CancellationToken ct);
        public Task<TItem> GetById(int id, CancellationToken ct);
        public Task<TItem> Add(TItem item, CancellationToken ct);
        public Task<TItem> Update(TItem item, CancellationToken ct);
        public Task<TItem> Delete(int id, CancellationToken ct);
    }
}
