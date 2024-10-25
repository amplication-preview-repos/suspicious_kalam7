using CompanionService.Infrastructure;

namespace CompanionService.APIs;

public class ReviewsService : ReviewsServiceBase
{
    public ReviewsService(CompanionServiceDbContext context)
        : base(context) { }
}
