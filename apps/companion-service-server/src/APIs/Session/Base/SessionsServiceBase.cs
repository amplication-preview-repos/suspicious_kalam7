using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using CompanionService.APIs.Extensions;
using CompanionService.Infrastructure;
using CompanionService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanionService.APIs;

public abstract class SessionsServiceBase : ISessionsService
{
    protected readonly CompanionServiceDbContext _context;

    public SessionsServiceBase(CompanionServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Session
    /// </summary>
    public async Task<Session> CreateSession(SessionCreateInput createDto)
    {
        var session = new SessionDbModel
        {
            ClientId = createDto.ClientId,
            CompanionId = createDto.CompanionId,
            CreatedAt = createDto.CreatedAt,
            Duration = createDto.Duration,
            EndTime = createDto.EndTime,
            Price = createDto.Price,
            StartTime = createDto.StartTime,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            session.Id = createDto.Id;
        }
        if (createDto.Reviews != null)
        {
            session.Reviews = await _context
                .Reviews.Where(review => createDto.Reviews.Select(t => t.Id).Contains(review.Id))
                .ToListAsync();
        }

        _context.Sessions.Add(session);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SessionDbModel>(session.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Session
    /// </summary>
    public async Task DeleteSession(SessionWhereUniqueInput uniqueId)
    {
        var session = await _context.Sessions.FindAsync(uniqueId.Id);
        if (session == null)
        {
            throw new NotFoundException();
        }

        _context.Sessions.Remove(session);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Sessions
    /// </summary>
    public async Task<List<Session>> Sessions(SessionFindManyArgs findManyArgs)
    {
        var sessions = await _context
            .Sessions.Include(x => x.Reviews)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return sessions.ConvertAll(session => session.ToDto());
    }

    /// <summary>
    /// Meta data about Session records
    /// </summary>
    public async Task<MetadataDto> SessionsMeta(SessionFindManyArgs findManyArgs)
    {
        var count = await _context.Sessions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Session
    /// </summary>
    public async Task<Session> Session(SessionWhereUniqueInput uniqueId)
    {
        var sessions = await this.Sessions(
            new SessionFindManyArgs { Where = new SessionWhereInput { Id = uniqueId.Id } }
        );
        var session = sessions.FirstOrDefault();
        if (session == null)
        {
            throw new NotFoundException();
        }

        return session;
    }

    /// <summary>
    /// Update one Session
    /// </summary>
    public async Task UpdateSession(SessionWhereUniqueInput uniqueId, SessionUpdateInput updateDto)
    {
        var session = updateDto.ToModel(uniqueId);

        if (updateDto.Reviews != null)
        {
            session.Reviews = await _context
                .Reviews.Where(review => updateDto.Reviews.Select(t => t).Contains(review.Id))
                .ToListAsync();
        }

        _context.Entry(session).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sessions.Any(e => e.Id == session.Id))
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
    /// Connect multiple Reviews records to Session
    /// </summary>
    public async Task ConnectReviews(
        SessionWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Sessions.Include(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reviews.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Reviews);

        foreach (var child in childrenToConnect)
        {
            parent.Reviews.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Reviews records from Session
    /// </summary>
    public async Task DisconnectReviews(
        SessionWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Sessions.Include(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reviews.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Reviews?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Reviews records for Session
    /// </summary>
    public async Task<List<Review>> FindReviews(
        SessionWhereUniqueInput uniqueId,
        ReviewFindManyArgs sessionFindManyArgs
    )
    {
        var reviews = await _context
            .Reviews.Where(m => m.SessionId == uniqueId.Id)
            .ApplyWhere(sessionFindManyArgs.Where)
            .ApplySkip(sessionFindManyArgs.Skip)
            .ApplyTake(sessionFindManyArgs.Take)
            .ApplyOrderBy(sessionFindManyArgs.SortBy)
            .ToListAsync();

        return reviews.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Reviews records for Session
    /// </summary>
    public async Task UpdateReviews(
        SessionWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] childrenIds
    )
    {
        var session = await _context
            .Sessions.Include(t => t.Reviews)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (session == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reviews.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        session.Reviews = children;
        await _context.SaveChangesAsync();
    }
}
