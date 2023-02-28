using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.SharedKernel.Interfaces
{
    public interface IRepository<T>  where T : class
    {

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAsync(T entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
