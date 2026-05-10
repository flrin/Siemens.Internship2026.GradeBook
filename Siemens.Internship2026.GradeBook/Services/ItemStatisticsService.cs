
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

public class ItemStatisticsService
{
    private readonly IRepository _repository;
    public ItemStatisticsService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<decimal> GetAverageItemValueAsync()
    {
        return _repository.GetAverageItemValueAsync();
    }

    public async Task<int> GetItemTotalCountAsync()
    {
        var itemCount = await _repository.GetItemTotalCountAsync();
        return itemCount;
    }
}