using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[ApiController()]
public class SubscriptionsController : SubscriptionsControllerBase
{
    public SubscriptionsController(ISubscriptionsService service)
        : base(service) { }
}
