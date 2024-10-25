using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;

namespace CompanionService.APIs;

public interface ISubscriptionsService
{
    /// <summary>
    /// Create one Subscription
    /// </summary>
    public Task<Subscription> CreateSubscription(SubscriptionCreateInput subscription);

    /// <summary>
    /// Delete one Subscription
    /// </summary>
    public Task DeleteSubscription(SubscriptionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Subscriptions
    /// </summary>
    public Task<List<Subscription>> Subscriptions(SubscriptionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Subscription records
    /// </summary>
    public Task<MetadataDto> SubscriptionsMeta(SubscriptionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Subscription
    /// </summary>
    public Task<Subscription> Subscription(SubscriptionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Subscription
    /// </summary>
    public Task UpdateSubscription(
        SubscriptionWhereUniqueInput uniqueId,
        SubscriptionUpdateInput updateDto
    );

    /// <summary>
    /// Get a user record for Subscription
    /// </summary>
    public Task<User> GetUser(SubscriptionWhereUniqueInput uniqueId);
}
