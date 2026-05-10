using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Services;
using Microsoft.Extensions.Logging;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _service;
    private readonly ILogger<ItemController> _logger;

    public ItemController(IItemService service, ILogger<ItemController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("GET api/item called");

        var itemsEnum = await _service.GetAllAsync();
        var items = itemsEnum.ToList();

        _logger.LogInformation("Retrieved {Count} items", items.Count);

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("GET api/item/{Id} called", id);

        try
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null)
            {
                _logger.LogWarning("Item with ID {Id} not found", id);
                return NotFound($"Item with Id {id} was not found.");
            }

            _logger.LogInformation("Retrieved item with ID {Id}: {@Item}", id, item);
            return Ok(item);

        }
        catch (BadHttpRequestException ex)
        {
            _logger.LogError("Bad request for item with ID {Id}: {Message}", id, ex.Message);
            return BadRequest(ex.Message);
        }

    }
}
