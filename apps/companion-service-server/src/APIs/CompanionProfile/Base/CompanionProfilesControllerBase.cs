using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CompanionProfilesControllerBase : ControllerBase
{
    protected readonly ICompanionProfilesService _service;

    public CompanionProfilesControllerBase(ICompanionProfilesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one CompanionProfile
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<CompanionProfile>> CreateCompanionProfile(
        CompanionProfileCreateInput input
    )
    {
        var companionProfile = await _service.CreateCompanionProfile(input);

        return CreatedAtAction(
            nameof(CompanionProfile),
            new { id = companionProfile.Id },
            companionProfile
        );
    }

    /// <summary>
    /// Delete one CompanionProfile
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCompanionProfile(
        [FromRoute()] CompanionProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCompanionProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CompanionProfiles
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<CompanionProfile>>> CompanionProfiles(
        [FromQuery()] CompanionProfileFindManyArgs filter
    )
    {
        return Ok(await _service.CompanionProfiles(filter));
    }

    /// <summary>
    /// Meta data about CompanionProfile records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CompanionProfilesMeta(
        [FromQuery()] CompanionProfileFindManyArgs filter
    )
    {
        return Ok(await _service.CompanionProfilesMeta(filter));
    }

    /// <summary>
    /// Get one CompanionProfile
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<CompanionProfile>> CompanionProfile(
        [FromRoute()] CompanionProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.CompanionProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one CompanionProfile
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCompanionProfile(
        [FromRoute()] CompanionProfileWhereUniqueInput uniqueId,
        [FromQuery()] CompanionProfileUpdateInput companionProfileUpdateDto
    )
    {
        try
        {
            await _service.UpdateCompanionProfile(uniqueId, companionProfileUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
