using CompanionService.Infrastructure;

namespace CompanionService.APIs;

public class SessionsService : SessionsServiceBase
{
    public SessionsService(CompanionServiceDbContext context)
        : base(context) { }
}
