using FullCardNumber.Core.CardAggregate;
using FullCardNumber.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Infrastruture.Data
{
    public class UserAuthRepository : IRepository<UsersAuth>
    {
        private readonly CardDbContext _cardDbContext;
        public UserAuthRepository(CardDbContext dbContext) : base()
        {
            _cardDbContext = dbContext;
        }

        public async Task<UsersAuth> AddAsync(UsersAuth entity, CancellationToken cancellationToken = default)
        {
            await _cardDbContext.UsersAuths.AddAsync(entity);
            await _cardDbContext.SaveChangesAsync();

            return entity;
        }

        public Task DeleteAsync(UsersAuth entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<UsersAuth> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsersAuth>> GetAsync(UsersAuth entity)
        {
            return await _cardDbContext.UsersAuths.Where(u => u.Name == entity.Name && u.Password == entity.Password).ToListAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UsersAuth entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
