using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[ApiController()]
public class ClientProfilesController : ClientProfilesControllerBase
{
    public ClientProfilesController(IClientProfilesService service)
        : base(service) { }
}
