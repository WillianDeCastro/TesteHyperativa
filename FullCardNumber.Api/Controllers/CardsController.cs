using FullCardNumber.Application.Cards.Command.BatchSaveCard;
using FullCardNumber.Application.Cards.Command.SaveCard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FullCardNumber.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CardsController : ControllerBase
    {
        private readonly ILogger<CardsController> _logger;
        private readonly ISender _sender;
        public CardsController(ILogger<CardsController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("AddCard")]
        public async Task<IActionResult> PostAddCard([FromBody] SaveCardCommand card, CancellationToken cancellationToken)
        {
            int idUser = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("sid")).Value);
            card.SetIdUser(idUser);

            int id = await _sender.Send(card);

            if (id == 0)
            {
                _logger.LogError("Não foi possível inserir o cartão");
                return BadRequest("Não foi possível inserir o cartão");
            }

            _logger.LogInformation($"Cartão cadastrado com sucesso request: {JsonSerializer.Serialize(card)} response {id}");

            return Ok(id);
        }

        [HttpPost("AddCard/Lote")]
        public async Task<IActionResult> PostBatch([FromBody] BatchSaveCardCommand cmd, CancellationToken cancellationToken)
        {
            int idUser = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("sid")).Value);

            foreach (var card in cmd.Cards)
            {
                card.SetIdUser(idUser);
            }


            IEnumerable<int> ids = await _sender.Send(cmd);

            if (!ids.Any() || ids.Count() == 0)
            {
                _logger.LogError("Não foi possível inserir os cartões");
                return BadRequest("Não foi possível inserir os cartões");
            }

            _logger.LogInformation($"Cartões cadastrado com sucesso request: {JsonSerializer.Serialize(cmd)} response {ids}");

            return Ok(ids);
        }
    }
}
