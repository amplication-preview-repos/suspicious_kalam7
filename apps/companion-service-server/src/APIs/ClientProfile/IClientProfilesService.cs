using CompanionService.APIs.Common;
using CompanionService.APIs.Dtos;

namespace CompanionService.APIs;

public interface IClientProfilesService
{
    /// <summary>
    /// Create one ClientProfile
    /// </summary>
    public Task<ClientProfile> CreateClientProfile(ClientProfileCreateInput clientprofile);

    /// <summary>
    /// Delete one ClientProfile
    /// </summary>
    public Task DeleteClientProfile(ClientProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ClientProfiles
    /// </summary>
    public Task<List<ClientProfile>> ClientProfiles(ClientProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ClientProfile records
    /// </summary>
    public Task<MetadataDto> ClientProfilesMeta(ClientProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ClientProfile
    /// </summary>
    public Task<ClientProfile> ClientProfile(ClientProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ClientProfile
    /// </summary>
    public Task UpdateClientProfile(
        ClientProfileWhereUniqueInput uniqueId,
        ClientProfileUpdateInput updateDto
    );
}
