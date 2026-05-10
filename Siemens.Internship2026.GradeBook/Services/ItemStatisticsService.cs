
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

public class ItemStatisticsService : IItemStatisticsService
{
    private readonly IItemStatisticsRepository _repository;
    public ItemStatisticsService(IItemStatisticsRepository repository)
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