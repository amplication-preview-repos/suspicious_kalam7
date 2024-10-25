using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using CompanionService.APIs.Extensions;
using CompanionService.Infrastructure;
using CompanionService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanionService.APIs;

public abstract class SubscriptionsServiceBase : ISubscriptionsService
{
    protected readonly CompanionServiceDbContext _context;

    public SubscriptionsServiceBase(CompanionServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Subscription
    /// </summary>
    public async Task<Subscription> CreateSubscription(SubscriptionCreateInput createDto)
    {
        var subscription = new SubscriptionDbModel
        {
            CreatedAt = createDto.CreatedAt,
            EndDate = createDto.EndDate,
            StartDate = createDto.StartDate,
            Status = createDto.Status,
            SubscriptionType = createDto.SubscriptionType,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            subscription.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            subscription.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SubscriptionDbModel>(subscription.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Subscription
    /// </summary>
    public async Task DeleteSubscription(SubscriptionWhereUniqueInput uniqueId)
    {
        var subscription = await _context.Subscriptions.FindAsync(uniqueId.Id);
        if (subscription == null)
        {
            throw new NotFoundException();
        }

        _context.Subscriptions.Remove(subscription);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Subscriptions
    /// </summary>
    public async Task<List<Subscription>> Subscriptions(SubscriptionFindManyArgs findManyArgs)
    {
        var subscriptions = await _context
            .Subscriptions.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return subscriptions.ConvertAll(subscription => subscription.ToDto());
    }

    /// <summary>
    /// Meta data about Subscription records
    /// </summary>
    public async Task<MetadataDto> SubscriptionsMeta(SubscriptionFindManyArgs findManyArgs)
    {
        var count = await _context.Subscriptions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Subscription
    /// </summary>
    public async Task<Subscription> Subscription(SubscriptionWhereUniqueInput uniqueId)
    {
        var subscriptions = await this.Subscriptions(
            new SubscriptionFindManyArgs { Where = new SubscriptionWhereInput { Id = uniqueId.Id } }
        );
        var subscription = subscriptions.FirstOrDefault();
        if (subscription == null)
        {
            throw new NotFoundException();
        }

        return subscription;
    }

    /// <summary>
    /// Update one Subscription
    /// </summary>
    public async Task UpdateSubscription(
        SubscriptionWhereUniqueInput uniqueId,
        SubscriptionUpdateInput updateDto
    )
    {
        var subscription = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            subscription.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(subscription).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Subscriptions.Any(e => e.Id == subscription.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a user record for Subscription
    /// </summary>
    public async Task<User> GetUser(SubscriptionWhereUniqueInput uniqueId)
    {
        var subscription = await _context
            .Subscriptions.Where(subscription => subscription.Id == uniqueId.Id)
            .Include(subscription => subscription.User)
            .FirstOrDefaultAsync();
        if (subscription == null)
        {
            throw new NotFoundException();
        }
        return subscription.User.ToDto();
    }
}
