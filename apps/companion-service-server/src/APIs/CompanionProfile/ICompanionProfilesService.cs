using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;

namespace CompanionService.APIs;

public interface ICompanionProfilesService
{
    /// <summary>
    /// Create one CompanionProfile
    /// </summary>
    public Task<CompanionProfile> CreateCompanionProfile(
        CompanionProfileCreateInput companionprofile
    );

    /// <summary>
    /// Delete one CompanionProfile
    /// </summary>
    public Task DeleteCompanionProfile(CompanionProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CompanionProfiles
    /// </summary>
    public Task<List<CompanionProfile>> CompanionProfiles(
        CompanionProfileFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about CompanionProfile records
    /// </summary>
    public Task<MetadataDto> CompanionProfilesMeta(CompanionProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CompanionProfile
    /// </summary>
    public Task<CompanionProfile> CompanionProfile(CompanionProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CompanionProfile
    /// </summary>
    public Task UpdateCompanionProfile(
        CompanionProfileWhereUniqueInput uniqueId,
        CompanionProfileUpdateInput updateDto
    );
}
