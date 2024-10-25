using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;

namespace CompanionService.APIs;

public interface ISessionsService
{
    /// <summary>
    /// Create one Session
    /// </summary>
    public Task<Session> CreateSession(SessionCreateInput session);

    /// <summary>
    /// Delete one Session
    /// </summary>
    public Task DeleteSession(SessionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Sessions
    /// </summary>
    public Task<List<Session>> Sessions(SessionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Session records
    /// </summary>
    public Task<MetadataDto> SessionsMeta(SessionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Session
    /// </summary>
    public Task<Session> Session(SessionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Session
    /// </summary>
    public Task UpdateSession(SessionWhereUniqueInput uniqueId, SessionUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Reviews records to Session
    /// </summary>
    public Task ConnectReviews(
        SessionWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] reviewsId
    );

    /// <summary>
    /// Disconnect multiple Reviews records from Session
    /// </summary>
    public Task DisconnectReviews(
        SessionWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] reviewsId
    );

    /// <summary>
    /// Find multiple Reviews records for Session
    /// </summary>
    public Task<List<Review>> FindReviews(
        SessionWhereUniqueInput uniqueId,
        ReviewFindManyArgs ReviewFindManyArgs
    );

    /// <summary>
    /// Update multiple Reviews records for Session
    /// </summary>
    public Task UpdateReviews(SessionWhereUniqueInput uniqueId, ReviewWhereUniqueInput[] reviewsId);
}
