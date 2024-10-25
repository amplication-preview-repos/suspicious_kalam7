using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;

namespace CompanionService.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<User> CreateUser(UserCreateInput user);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<User>> Users(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<User> User(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Payments records to User
    /// </summary>
    public Task ConnectPayments(
        UserWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Disconnect multiple Payments records from User
    /// </summary>
    public Task DisconnectPayments(
        UserWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Find multiple Payments records for User
    /// </summary>
    public Task<List<Payment>> FindPayments(
        UserWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple Payments records for User
    /// </summary>
    public Task UpdatePayments(UserWhereUniqueInput uniqueId, PaymentWhereUniqueInput[] paymentsId);

    /// <summary>
    /// Connect multiple Subscriptions records to User
    /// </summary>
    public Task ConnectSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );

    /// <summary>
    /// Disconnect multiple Subscriptions records from User
    /// </summary>
    public Task DisconnectSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );

    /// <summary>
    /// Find multiple Subscriptions records for User
    /// </summary>
    public Task<List<Subscription>> FindSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionFindManyArgs SubscriptionFindManyArgs
    );

    /// <summary>
    /// Update multiple Subscriptions records for User
    /// </summary>
    public Task UpdateSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );
}
