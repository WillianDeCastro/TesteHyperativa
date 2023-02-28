using FullCardNumber.Core.CardAggregate;
using FullCardNumber.Core.Interfaces;
using FullCardNumber.SharedKernel.Interfaces;

namespace FullCardNumber.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<UsersAuth> _repo;

        public AuthService(IRepository<UsersAuth> repo)
        {
            _repo = repo;
        }

        public async Task<UsersAuth> CreateUserAsync(string username, string password)
        {
            var newUser = new UsersAuth(username, password);

            newUser = await _repo.AddAsync(newUser);

            return newUser;
        }

        public async Task<UsersAuth> SignInAsync(string username, string password)
        {
            UsersAuth user = new();

            var userFounded = await _repo.GetAsync(new UsersAuth
            {
                Name = username,
                Password = password
            });

            if (userFounded != null)
            {
                user = userFounded.FirstOrDefault();
            }


            return user;
        }
    }
}
