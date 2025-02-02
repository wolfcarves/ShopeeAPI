using Microsoft.AspNetCore.Mvc;
using ShopeeAPI.Modules.Stores.DTO;
using ShopeeAPI.Modules.Stores.Entities;
using ShopeeAPI.Modules.Stores.Services;

namespace ShopeeAPI.Modules.Products.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    private readonly ILogger<StoreController> _logger;

    public StoreController(IStoreService storeService, ILogger<StoreController> logger)
    {
        _storeService = storeService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoreDTO>>> GetStores()
    {
        var stores = await _storeService.GetAllStores();
        return Ok(stores);
    }

    [HttpPost]
    public async Task<ActionResult<Store>> CreateStore([FromBody] StoreCreateDTO body)
    {
        try
        {
            var store = await _storeService.AddStore(body);
            return Ok(store);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpGet("{storeId}")]
    public async Task<ActionResult<StoreDTO?>> GetStore(int storeId)
    {
        try
        {
            var store = await _storeService.GetStoreById(storeId);
            return Ok(store);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPatch("{storeId}")]
    public async Task<ActionResult<StoreDTO>> UpdateStore(int storeId, StoreUpdateDTO data)
    {
        try
        {
            var updatedStore = await _storeService.UpdateStore(storeId, data);
            return Ok(updatedStore);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{storeId}")]
    public async Task<ActionResult<StoreDTO>> DeleteStore(int storeId)
    {
        try
        {
            var deletedStore = await _storeService.DeleteStore(storeId);
            return deletedStore;
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}