using CompanionService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanionService.Infrastructure;

public class CompanionServiceDbContext : DbContext
{
    public CompanionServiceDbContext(DbContextOptions<CompanionServiceDbContext> options)
        : base(options) { }

    public DbSet<SubscriptionDbModel> Subscriptions { get; set; }

    public DbSet<SessionDbModel> Sessions { get; set; }

    public DbSet<ClientProfileDbModel> ClientProfiles { get; set; }

    public DbSet<ReviewDbModel> Reviews { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }

    public DbSet<CompanionProfileDbModel> CompanionProfiles { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
