using CompanionService.Infrastructure;

namespace CompanionService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(CompanionServiceDbContext context)
        : base(context) { }
}
