using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SubscriptionsControllerBase : ControllerBase
{
    protected readonly ISubscriptionsService _service;

    public SubscriptionsControllerBase(ISubscriptionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Subscription
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Subscription>> CreateSubscription(SubscriptionCreateInput input)
    {
        var subscription = await _service.CreateSubscription(input);

        return CreatedAtAction(nameof(Subscription), new { id = subscription.Id }, subscription);
    }

    /// <summary>
    /// Delete one Subscription
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSubscription(
        [FromRoute()] SubscriptionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteSubscription(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Subscriptions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Subscription>>> Subscriptions(
        [FromQuery()] SubscriptionFindManyArgs filter
    )
    {
        return Ok(await _service.Subscriptions(filter));
    }

    /// <summary>
    /// Meta data about Subscription records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SubscriptionsMeta(
        [FromQuery()] SubscriptionFindManyArgs filter
    )
    {
        return Ok(await _service.SubscriptionsMeta(filter));
    }

    /// <summary>
    /// Get one Subscription
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Subscription>> Subscription(
        [FromRoute()] SubscriptionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Subscription(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Subscription
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSubscription(
        [FromRoute()] SubscriptionWhereUniqueInput uniqueId,
        [FromQuery()] SubscriptionUpdateInput subscriptionUpdateDto
    )
    {
        try
        {
            await _service.UpdateSubscription(uniqueId, subscriptionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user record for Subscription
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] SubscriptionWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
