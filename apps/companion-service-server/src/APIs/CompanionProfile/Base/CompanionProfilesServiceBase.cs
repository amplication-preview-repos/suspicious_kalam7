using CompanionService.APIs;
using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;
using CompanionService.APIs.Errors;
using CompanionService.APIs.Extensions;
using CompanionService.Infrastructure;
using CompanionService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanionService.APIs;

public abstract class CompanionProfilesServiceBase : ICompanionProfilesService
{
    protected readonly CompanionServiceDbContext _context;

    public CompanionProfilesServiceBase(CompanionServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one CompanionProfile
    /// </summary>
    public async Task<CompanionProfile> CreateCompanionProfile(
        CompanionProfileCreateInput createDto
    )
    {
        var companionProfile = new CompanionProfileDbModel
        {
            Availability = createDto.Availability,
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            HourlyRate = createDto.HourlyRate,
            Ratings = createDto.Ratings,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            companionProfile.Id = createDto.Id;
        }

        _context.CompanionProfiles.Add(companionProfile);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CompanionProfileDbModel>(companionProfile.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one CompanionProfile
    /// </summary>
    public async Task DeleteCompanionProfile(CompanionProfileWhereUniqueInput uniqueId)
    {
        var companionProfile = await _context.CompanionProfiles.FindAsync(uniqueId.Id);
        if (companionProfile == null)
        {
            throw new NotFoundException();
        }

        _context.CompanionProfiles.Remove(companionProfile);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CompanionProfiles
    /// </summary>
    public async Task<List<CompanionProfile>> CompanionProfiles(
        CompanionProfileFindManyArgs findManyArgs
    )
    {
        var companionProfiles = await _context
            .CompanionProfiles.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return companionProfiles.ConvertAll(companionProfile => companionProfile.ToDto());
    }

    /// <summary>
    /// Meta data about CompanionProfile records
    /// </summary>
    public async Task<MetadataDto> CompanionProfilesMeta(CompanionProfileFindManyArgs findManyArgs)
    {
        var count = await _context.CompanionProfiles.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one CompanionProfile
    /// </summary>
    public async Task<CompanionProfile> CompanionProfile(CompanionProfileWhereUniqueInput uniqueId)
    {
        var companionProfiles = await this.CompanionProfiles(
            new CompanionProfileFindManyArgs
            {
                Where = new CompanionProfileWhereInput { Id = uniqueId.Id }
            }
        );
        var companionProfile = companionProfiles.FirstOrDefault();
        if (companionProfile == null)
        {
            throw new NotFoundException();
        }

        return companionProfile;
    }

    /// <summary>
    /// Update one CompanionProfile
    /// </summary>
    public async Task UpdateCompanionProfile(
        CompanionProfileWhereUniqueInput uniqueId,
        CompanionProfileUpdateInput updateDto
    )
    {
        var companionProfile = updateDto.ToModel(uniqueId);

        _context.Entry(companionProfile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CompanionProfiles.Any(e => e.Id == companionProfile.Id))
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
