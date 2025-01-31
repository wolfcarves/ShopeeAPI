using Microsoft.AspNetCore.Mvc;
using ShopeeAPI.Modules.Owners.DTO;
using ShopeeAPI.Modules.Owners.Entities;
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

    [HttpPost]
    public async Task<ActionResult<Owner>> CreateOwner(OwnerCreateDTO body)
    {
        try
        {
            var createdOwner = await _ownerService.AddOwner(body);
            return CreatedAtAction(nameof(GetOwner), new { id = createdOwner.Id }, createdOwner);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Owner>> GetOwner(int id)
    {
        try
        {
            var owner = await _ownerService.GetOneOwnerById(id);
            return Ok(owner);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Owner>> UpdateOwnerFullName(int id, OwnerUpdateDTO ownerUpdatedData)
    {
        try
        {
            var updatedOwner = await _ownerService.UpdateOwner(id, ownerUpdatedData);

            return CreatedAtAction(nameof(GetOwner), new { id = updatedOwner.Id }, updatedOwner);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}