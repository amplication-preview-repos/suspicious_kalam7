using CompanionService.APIs.Dtos;
using CompanionService.Infrastructure.Models;

namespace CompanionService.APIs.Extensions;

public static class UsersExtensions
{
    public static User ToDto(this UserDbModel model)
    {
        return new User
        {
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            Location = model.Location,
            Password = model.Password,
            Payments = model.Payments?.Select(x => x.Id).ToList(),
            Role = model.Role,
            Roles = model.Roles,
            Subscriptions = model.Subscriptions?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
        };
    }

    public static UserDbModel ToModel(this UserUpdateInput updateDto, UserWhereUniqueInput uniqueId)
    {
        var user = new UserDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            Location = updateDto.Location,
            Role = updateDto.Role
        };

        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }

        return user;
    }
}
