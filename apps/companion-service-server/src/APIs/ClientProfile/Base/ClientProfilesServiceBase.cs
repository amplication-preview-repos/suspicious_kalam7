using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using CompanionService.APIs.Extensions;
using CompanionService.Infrastructure;
using CompanionService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanionService.APIs;

public abstract class ClientProfilesServiceBase : IClientProfilesService
{
    protected readonly CompanionServiceDbContext _context;

    public ClientProfilesServiceBase(CompanionServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ClientProfile
    /// </summary>
    public async Task<ClientProfile> CreateClientProfile(ClientProfileCreateInput createDto)
    {
        var clientProfile = new ClientProfileDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Preferences = createDto.Preferences,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            clientProfile.Id = createDto.Id;
        }

        _context.ClientProfiles.Add(clientProfile);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ClientProfileDbModel>(clientProfile.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ClientProfile
    /// </summary>
    public async Task DeleteClientProfile(ClientProfileWhereUniqueInput uniqueId)
    {
        var clientProfile = await _context.ClientProfiles.FindAsync(uniqueId.Id);
        if (clientProfile == null)
        {
            throw new NotFoundException();
        }

        _context.ClientProfiles.Remove(clientProfile);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ClientProfiles
    /// </summary>
    public async Task<List<ClientProfile>> ClientProfiles(ClientProfileFindManyArgs findManyArgs)
    {
        var clientProfiles = await _context
            .ClientProfiles.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return clientProfiles.ConvertAll(clientProfile => clientProfile.ToDto());
    }

    /// <summary>
    /// Meta data about ClientProfile records
    /// </summary>
    public async Task<MetadataDto> ClientProfilesMeta(ClientProfileFindManyArgs findManyArgs)
    {
        var count = await _context.ClientProfiles.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ClientProfile
    /// </summary>
    public async Task<ClientProfile> ClientProfile(ClientProfileWhereUniqueInput uniqueId)
    {
        var clientProfiles = await this.ClientProfiles(
            new ClientProfileFindManyArgs
            {
                Where = new ClientProfileWhereInput { Id = uniqueId.Id }
            }
        );
        var clientProfile = clientProfiles.FirstOrDefault();
        if (clientProfile == null)
        {
            throw new NotFoundException();
        }

        return clientProfile;
    }

    /// <summary>
    /// Update one ClientProfile
    /// </summary>
    public async Task UpdateClientProfile(
        ClientProfileWhereUniqueInput uniqueId,
        ClientProfileUpdateInput updateDto
    )
    {
        var clientProfile = updateDto.ToModel(uniqueId);

        _context.Entry(clientProfile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ClientProfiles.Any(e => e.Id == clientProfile.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
