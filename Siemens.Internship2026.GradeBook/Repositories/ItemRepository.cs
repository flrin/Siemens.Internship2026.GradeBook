using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class ItemRepository : IRepository
{
    protected readonly List<Item> _items = new();
    protected int _nextId = 1;

    public virtual Task<Item?> GetByIdAsync(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id && i.IsActive);
        return Task.FromResult(item);
    }

    public virtual Task<IEnumerable<Item>> GetAllAsync()
    {
        var items = _items.Where(i => i.IsActive).AsEnumerable();
        return Task.FromResult(items);
    }

    public Task<int> GetItemTotalCountAsync()
    {
        var itemCount = _items.Count();
        return Task.FromResult(itemCount);
    }

    public Task<decimal> GetAverageItemValueAsync()
    {
        var itemAverageValue = _items.Any() ? _items.Average(i => i.Value) : 0;
        return Task.FromResult(itemAverageValue);
    }
}
