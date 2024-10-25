using CompanionService.Infrastructure;

namespace CompanionService.APIs;

public class ClientProfilesService : ClientProfilesServiceBase
{
    public ClientProfilesService(CompanionServiceDbContext context)
        : base(context) { }
}
