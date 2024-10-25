using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[ApiController()]
public class SessionsController : SessionsControllerBase
{
    public SessionsController(ISessionsService service)
        : base(service) { }
}
