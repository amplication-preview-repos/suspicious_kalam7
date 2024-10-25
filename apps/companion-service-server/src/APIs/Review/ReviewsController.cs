using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs;

[ApiController()]
public class ReviewsController : ReviewsControllerBase
{
    public ReviewsController(IReviewsService service)
        : base(service) { }
}
