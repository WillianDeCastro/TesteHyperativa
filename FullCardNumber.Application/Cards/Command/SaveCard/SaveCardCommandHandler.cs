using FullCardNumber.Application.UsersAuth.Command.SignIn;
using FullCardNumber.Core.Interfaces;
using FullCardNumber.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FullCardNumber.Application.Cards.Command.SaveCard
{
    public class SaveCardCommandHandler : IRequestHandler<SaveCardCommand, int>
    {
        private readonly ICardNumberService _service;
        private readonly ILogger<SaveCardCommandHandler> _logger;
        public SaveCardCommandHandler(ICardNumberService service, ILogger<SaveCardCommandHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<int> Handle(SaveCardCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var cardId = await _service.AddCardAsync(request.Name, request.Number, request.IdUser);
                return cardId;
            }
            catch (Exception ex)
            {
                _logger.LogError(@$"Erro ao gravar o cartão com os seguintes dados {JsonSerializer.Serialize(request)} 
                                    erro : {JsonSerializer.Serialize(ex)}");
                return 0;
            }

        }
    }
}
