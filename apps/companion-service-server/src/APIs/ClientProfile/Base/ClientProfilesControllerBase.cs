using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ClientProfilesControllerBase : ControllerBase
{
    protected readonly IClientProfilesService _service;

    public ClientProfilesControllerBase(IClientProfilesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ClientProfile
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ClientProfile>> CreateClientProfile(
        ClientProfileCreateInput input
    )
    {
        var clientProfile = await _service.CreateClientProfile(input);

        return CreatedAtAction(nameof(ClientProfile), new { id = clientProfile.Id }, clientProfile);
    }

    /// <summary>
    /// Delete one ClientProfile
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteClientProfile(
        [FromRoute()] ClientProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteClientProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ClientProfiles
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ClientProfile>>> ClientProfiles(
        [FromQuery()] ClientProfileFindManyArgs filter
    )
    {
        return Ok(await _service.ClientProfiles(filter));
    }

    /// <summary>
    /// Meta data about ClientProfile records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ClientProfilesMeta(
        [FromQuery()] ClientProfileFindManyArgs filter
    )
    {
        return Ok(await _service.ClientProfilesMeta(filter));
    }

    /// <summary>
    /// Get one ClientProfile
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ClientProfile>> ClientProfile(
        [FromRoute()] ClientProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ClientProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ClientProfile
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateClientProfile(
        [FromRoute()] ClientProfileWhereUniqueInput uniqueId,
        [FromQuery()] ClientProfileUpdateInput clientProfileUpdateDto
    )
    {
        try
        {
            await _service.UpdateClientProfile(uniqueId, clientProfileUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
