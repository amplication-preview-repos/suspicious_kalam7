using CompanionService.APIs.Dtos;
using CompanionService.Infrastructure.Models;

namespace CompanionService.APIs.Extensions;

public static class SessionsExtensions
{
    public static Session ToDto(this SessionDbModel model)
    {
        return new Session
        {
            ClientId = model.ClientId,
            CompanionId = model.CompanionId,
            CreatedAt = model.CreatedAt,
            Duration = model.Duration,
            EndTime = model.EndTime,
            Id = model.Id,
            Price = model.Price,
            Reviews = model.Reviews?.Select(x => x.Id).ToList(),
            StartTime = model.StartTime,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static SessionDbModel ToModel(
        this SessionUpdateInput updateDto,
        SessionWhereUniqueInput uniqueId
    )
    {
        var session = new SessionDbModel
        {
            Id = uniqueId.Id,
            ClientId = updateDto.ClientId,
            CompanionId = updateDto.CompanionId,
            Duration = updateDto.Duration,
            EndTime = updateDto.EndTime,
            Price = updateDto.Price,
            StartTime = updateDto.StartTime
        };

        if (updateDto.CreatedAt != null)
        {
            session.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            session.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return session;
    }
}
