using CompanionService.APIs.Dtos;
using CompanionService.Infrastructure.Models;

namespace CompanionService.APIs.Extensions;

public static class ClientProfilesExtensions
{
    public static ClientProfile ToDto(this ClientProfileDbModel model)
    {
        return new ClientProfile
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Preferences = model.Preferences,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ClientProfileDbModel ToModel(
        this ClientProfileUpdateInput updateDto,
        ClientProfileWhereUniqueInput uniqueId
    )
    {
        var clientProfile = new ClientProfileDbModel
        {
            Id = uniqueId.Id,
            Preferences = updateDto.Preferences
        };

        if (updateDto.CreatedAt != null)
        {
            clientProfile.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            clientProfile.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return clientProfile;
    }
}
