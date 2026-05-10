using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;
using Siemens.Internship2026.GradeBook.Utils;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class ExternalEndpointItemRepository : IItemRepository, IItemStatisticsRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _endpointUrl;

    public ExternalEndpointItemRepository(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _endpointUrl = configuration["ExternalEndpointUrl"];
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ExternalEndpointResponseWrapper>(_endpointUrl);

        var items = response?.Items;

        return items?.Where(item => item.IsActive == true) ?? Enumerable.Empty<Item>();
    }

    public async Task<decimal> GetAverageItemValueAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ExternalEndpointResponseWrapper>(_endpointUrl);

        var items = response?.Items;
        
        return items?.Where(item => item.IsActive == true).Average(item => item.Value) ?? 0;
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<ExternalEndpointResponseWrapper>(_endpointUrl);

        var items = response?.Items;

        return items?.FirstOrDefault(item => item.Id == id && item.IsActive == true);
    }

    public async Task<int> GetItemTotalCountAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ExternalEndpointResponseWrapper>(_endpointUrl);

        var items = response?.Items;
        return items?.Count(item => item.IsActive == true) ?? 0;
    }
}