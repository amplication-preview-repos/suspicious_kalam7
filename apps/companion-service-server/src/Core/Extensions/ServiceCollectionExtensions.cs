using CompanionService.APIs;

namespace CompanionService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IClientProfilesService, ClientProfilesService>();
        services.AddScoped<ICompanionProfilesService, CompanionProfilesService>();
        services.AddScoped<IPaymentsService, PaymentsService>();
        services.AddScoped<IReviewsService, ReviewsService>();
        services.AddScoped<ISessionsService, SessionsService>();
        services.AddScoped<ISubscriptionsService, SubscriptionsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
