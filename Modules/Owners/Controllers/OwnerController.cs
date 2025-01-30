using Microsoft.AspNetCore.Mvc;
using ShopeeAPI.Modules.Owners.Entities;
using ShopeeAPI.Modules.Owners.Repositories;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{

    private readonly IOwnerRepository _ownerRepo;

    public OwnerController(IOwnerRepository ownerRepo)
    {
        _ownerRepo = ownerRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Owner>>> GetAllOwners()
    {
        var owners = await _ownerRepo.GetAllAsync();
        return Ok(owners);
    }



}