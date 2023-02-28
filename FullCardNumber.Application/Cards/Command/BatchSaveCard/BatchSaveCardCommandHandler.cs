using FullCardNumber.Application.Cards.Command.SaveCard;
using FullCardNumber.Application.UsersAuth.Command.SignIn;
using FullCardNumber.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FullCardNumber.Application.Cards.Command.BatchSaveCard
{
    public class BatchSaveCardCommandHandler : IRequestHandler<BatchSaveCardCommand, IEnumerable<int>>
    {
        private readonly ICardNumberService _service;
        private readonly ILogger<SaveCardCommandHandler> _logger;
        public BatchSaveCardCommandHandler(ICardNumberService service, ILogger<SaveCardCommandHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IEnumerable<int>> Handle(BatchSaveCardCommand request, CancellationToken cancellationToken)
        {
            var cardsIds = new List<int>();
            try
            {
                foreach (var card in request.Cards)
                {
                    int idCard = await _service.AddCardAsync(card.Name, card.Number, card.IdUser);
                    cardsIds.Add(idCard);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(@$"Erro ao gravar o cartão com os seguintes dados {JsonSerializer.Serialize(request)} 
                                    erro : {JsonSerializer.Serialize(ex)}");
            }

            return cardsIds;

        }
    }
}
