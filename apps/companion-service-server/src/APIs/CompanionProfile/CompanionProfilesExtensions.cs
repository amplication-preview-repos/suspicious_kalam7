using CompanionService.APIs.Dtos;
using CompanionService.Infrastructure.Models;

namespace CompanionService.APIs.Extensions;

public static class CompanionProfilesExtensions
{
    public static CompanionProfile ToDto(this CompanionProfileDbModel model)
    {
        return new CompanionProfile
        {
            Availability = model.Availability,
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            HourlyRate = model.HourlyRate,
            Id = model.Id,
            Ratings = model.Ratings,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CompanionProfileDbModel ToModel(
        this CompanionProfileUpdateInput updateDto,
        CompanionProfileWhereUniqueInput uniqueId
    )
    {
        var companionProfile = new CompanionProfileDbModel
        {
            Id = uniqueId.Id,
            Availability = updateDto.Availability,
            Description = updateDto.Description,
            HourlyRate = updateDto.HourlyRate,
            Ratings = updateDto.Ratings
        };

        if (updateDto.CreatedAt != null)
        {
            companionProfile.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            companionProfile.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return companionProfile;
    }
}
