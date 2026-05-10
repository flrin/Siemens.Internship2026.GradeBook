using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Services;
using System.Reflection.PortableExecutable;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/statistics")]
public class ItemStatisticsController : ControllerBase
{
    private readonly IItemStatisticsService _service;
    private readonly ILogger<ItemStatisticsController> _logger;

    public ItemStatisticsController(IItemStatisticsService service, ILogger<ItemStatisticsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("average")]
    public async Task<IActionResult> GetAverageItemValue()
    {
        _logger.LogInformation("GET api/statistics/average called");

        var averageValue = await _service.GetAverageItemValueAsync();

        _logger.LogInformation("Average value: {AverageValue}", averageValue);

        return Ok(new
        {
            AverageValue = averageValue
        });
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetItemTotalCount()
    {
        _logger.LogInformation("GET api/statistics/count called");

        var totalCount = await _service.GetItemTotalCountAsync();
        _logger.LogInformation("Total count: {TotalCount}", totalCount);
        return Ok(new
        {
            TotalCount = totalCount
        });
    }


}
