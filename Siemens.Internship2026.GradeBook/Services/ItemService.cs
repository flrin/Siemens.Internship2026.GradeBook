
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

public class ItemService : IItemService
{
    private readonly IRepository _repository;
    public ItemService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Item?> GetByIdAsync(int id)
    {

        if (id < 0)
        {
            throw new BadHttpRequestException($"Id {id} must be a positive integer.");
        }

        var item = await _repository.GetByIdAsync(id);

        if (item == null)
        {
            throw new KeyNotFoundException($"Item with Id {id} was not found.");
        }

        return item;
    }
    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items;
    }
}