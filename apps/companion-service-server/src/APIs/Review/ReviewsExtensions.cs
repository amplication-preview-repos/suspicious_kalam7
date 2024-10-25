using CompanionService.APIs.Dtos;
using CompanionService.Infrastructure.Models;

namespace CompanionService.APIs.Extensions;

public static class ReviewsExtensions
{
    public static Review ToDto(this ReviewDbModel model)
    {
        return new Review
        {
            Comments = model.Comments,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Rating = model.Rating,
            Session = model.SessionId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ReviewDbModel ToModel(
        this ReviewUpdateInput updateDto,
        ReviewWhereUniqueInput uniqueId
    )
    {
        var review = new ReviewDbModel
        {
            Id = uniqueId.Id,
            Comments = updateDto.Comments,
            Rating = updateDto.Rating
        };

        if (updateDto.CreatedAt != null)
        {
            review.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Session != null)
        {
            review.SessionId = updateDto.Session;
        }
        if (updateDto.UpdatedAt != null)
        {
            review.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return review;
    }
}
