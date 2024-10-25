using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[ApiController()]
public class CompanionProfilesController : CompanionProfilesControllerBase
{
    public CompanionProfilesController(ICompanionProfilesService service)
        : base(service) { }
}
