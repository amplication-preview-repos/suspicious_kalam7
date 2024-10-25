using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SessionsControllerBase : ControllerBase
{
    protected readonly ISessionsService _service;

    public SessionsControllerBase(ISessionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Session
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Session>> CreateSession(SessionCreateInput input)
    {
        var session = await _service.CreateSession(input);

        return CreatedAtAction(nameof(Session), new { id = session.Id }, session);
    }

    /// <summary>
    /// Delete one Session
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSession([FromRoute()] SessionWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteSession(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Sessions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Session>>> Sessions(
        [FromQuery()] SessionFindManyArgs filter
    )
    {
        return Ok(await _service.Sessions(filter));
    }

    /// <summary>
    /// Meta data about Session records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SessionsMeta(
        [FromQuery()] SessionFindManyArgs filter
    )
    {
        return Ok(await _service.SessionsMeta(filter));
    }

    /// <summary>
    /// Get one Session
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Session>> Session([FromRoute()] SessionWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Session(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Session
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSession(
        [FromRoute()] SessionWhereUniqueInput uniqueId,
        [FromQuery()] SessionUpdateInput sessionUpdateDto
    )
    {
        try
        {
            await _service.UpdateSession(uniqueId, sessionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Reviews records to Session
    /// </summary>
    [HttpPost("{Id}/reviews")]
    public async Task<ActionResult> ConnectReviews(
        [FromRoute()] SessionWhereUniqueInput uniqueId,
        [FromQuery()] ReviewWhereUniqueInput[] reviewsId
    )
    {
        try
        {
            await _service.ConnectReviews(uniqueId, reviewsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Reviews records from Session
    /// </summary>
    [HttpDelete("{Id}/reviews")]
    public async Task<ActionResult> DisconnectReviews(
        [FromRoute()] SessionWhereUniqueInput uniqueId,
        [FromBody()] ReviewWhereUniqueInput[] reviewsId
    )
    {
        try
        {
            await _service.DisconnectReviews(uniqueId, reviewsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Reviews records for Session
    /// </summary>
    [HttpGet("{Id}/reviews")]
    public async Task<ActionResult<List<Review>>> FindReviews(
        [FromRoute()] SessionWhereUniqueInput uniqueId,
        [FromQuery()] ReviewFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindReviews(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Reviews records for Session
    /// </summary>
    [HttpPatch("{Id}/reviews")]
    public async Task<ActionResult> UpdateReviews(
        [FromRoute()] SessionWhereUniqueInput uniqueId,
        [FromBody()] ReviewWhereUniqueInput[] reviewsId
    )
    {
        try
        {
            await _service.UpdateReviews(uniqueId, reviewsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
