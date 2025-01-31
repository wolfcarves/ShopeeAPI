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

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Store>>> GetStores()
    {
        var result = await _storeService.GetAllStores();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Store>> CreateStore([FromBody] StoreCreateDTO body)
    {
        try
        {
            var createdStore = await _storeService.AddStore(body);
            return createdStore;
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


}