using FullCardNumber.Core.CardAggregate;
using FullCardNumber.Core.Interfaces;
using FullCardNumber.SharedKernel.Interfaces;

namespace FullCardNumber.Core.Services
{
    public class CardNumberService : ICardNumberService
    {
        private readonly IRepository<Card> _repo;

        public CardNumberService(IRepository<Card> repo)
        {
            _repo = repo;
        }

        public async Task<int> AddCardAsync(string name, string number, int idUser)
        {
            var card = new Card
            {
                Batch = "wwwww",
                Date = DateTime.Now,
                Name = name,
                Number = number,
                UsersAuthId = idUser
            };

            await _repo.AddAsync(card);

            return card.Id;
        }
    }
}
