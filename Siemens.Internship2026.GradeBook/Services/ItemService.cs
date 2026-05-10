
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;
    public ItemService(IItemRepository repository)
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

        return item;
    }
    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items;
    }
}