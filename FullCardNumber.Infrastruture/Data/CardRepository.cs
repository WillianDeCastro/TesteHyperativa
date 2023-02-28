using FullCardNumber.Core.CardAggregate;
using FullCardNumber.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Infrastruture.Data
{
    public class CardRepository : IRepository<Card>
    {
        private readonly CardDbContext _cardDbContext;
        public CardRepository(CardDbContext dbContext) : base()
        {
            _cardDbContext = dbContext;
        }

        public async Task<Card> AddAsync(Card entity, CancellationToken cancellationToken = default)
        {
            await _cardDbContext.Cards.AddAsync(entity);
            await _cardDbContext.SaveChangesAsync();

            return entity;
        }

        public Task DeleteAsync(Card entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Card> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> GetAsync(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Card entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
