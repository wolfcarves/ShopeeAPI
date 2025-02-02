using Microsoft.AspNetCore.Mvc;
using ShopeeAPI.Modules.Owners.DTO;
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
    public async Task<ActionResult<IEnumerable<OwnerDTO>>> GetOwners()
    {
        var owners = await _ownerService.GetAllOwners();

        if (!owners.Any()) return NotFound(new { statusCode = 404, message = "No owners to fetch" });

        return Ok(owners);
    }

    [HttpPost]
    public async Task<ActionResult<OwnerDTO>> CreateOwner(OwnerCreateDTO body)
    {
        try
        {
            var createdOwner = await _ownerService.AddOwner(body);
            return CreatedAtAction(nameof(GetOwner), new { id = createdOwner.Id }, createdOwner);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { statusCode = 409, message = ex.Message });
        }
    }

    [HttpGet("{ownerId}")]
    public async Task<ActionResult<OwnerDTO>> GetOwner(int ownerId)
    {
        try
        {
            var owner = await _ownerService.GetOneOwnerById(ownerId);
            return Ok(owner);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { statusCode = 404, message = ex.Message });
        }
    }

    [HttpPatch("{ownerId}")]
    public async Task<ActionResult<OwnerDTO>> UpdateOwnerFullName(int ownerId, OwnerUpdateDTO ownerUpdatedData)
    {
        try
        {
            var updatedOwner = await _ownerService.UpdateOwner(ownerId, ownerUpdatedData);

            return CreatedAtAction(nameof(GetOwner), new { ownerId = updatedOwner.Id }, updatedOwner);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{ownerId}")]
    public async Task<ActionResult<OwnerDTO>> DeleteOwner(int ownerId)
    {
        try
        {
            var deletedOwner = await _ownerService.DeleteOwner(ownerId);
            return Ok(deletedOwner);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}