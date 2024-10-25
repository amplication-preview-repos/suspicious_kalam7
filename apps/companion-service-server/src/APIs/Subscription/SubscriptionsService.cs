using CompanionService.Infrastructure;

namespace CompanionService.APIs;

public class SubscriptionsService : SubscriptionsServiceBase
{
    public SubscriptionsService(CompanionServiceDbContext context)
        : base(context) { }
}
