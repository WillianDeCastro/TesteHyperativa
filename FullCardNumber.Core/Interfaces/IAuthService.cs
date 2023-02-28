using FullCardNumber.Core.CardAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Core.Interfaces
{
    public interface IAuthService
    {
        Task<UsersAuth> SignInAsync(string username, string password);
        Task<UsersAuth> CreateUserAsync(string username, string password);
    }
}
