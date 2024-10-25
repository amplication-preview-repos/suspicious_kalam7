using CompanionService.Infrastructure;

namespace CompanionService.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(CompanionServiceDbContext context)
        : base(context) { }
}
