using FullCardNumber.Core.CardAggregate;
using FullCardNumber.Infrastruture.Data.Config;
using FullCardNumber.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FullCardNumber.Infrastruture.Data
{
    public class CardDbContext : DbContext
    {
        private readonly IMediator? _mediator;

        public CardDbContext(DbContextOptions<CardDbContext> options, IMediator? mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Card> Cards => Set<Card>();
        public DbSet<UsersAuth> UsersAuths => Set<UsersAuth>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsersAuthConfiguration());
            builder.ApplyConfiguration(new CardConfiguration());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            if (_mediator == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
