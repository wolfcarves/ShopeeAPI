using Microsoft.AspNetCore.Mvc;
using ShopeeAPI.Modules.Owners.Entities;
using ShopeeAPI.Modules.Owners.Repositories;
using ShopeeAPI.Modules.Owners.Services;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
    {
        var owners = await _ownerService.GetAllOwners();
        return Ok(owners);
    }



}