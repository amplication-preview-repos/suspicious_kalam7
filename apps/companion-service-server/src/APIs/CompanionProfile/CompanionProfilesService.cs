using CompanionService.Infrastructure;

namespace CompanionService.APIs;

public class CompanionProfilesService : CompanionProfilesServiceBase
{
    public CompanionProfilesService(CompanionServiceDbContext context)
        : base(context) { }
}
