using FullCardNumber.Api.Identity.Auth;
using FullCardNumber.Application.UsersAuth.Command.SignIn;
using FullCardNumber.Application.UsersAuth.Command.SignUp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FullCardNumber.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IConfiguration config, ILogger<AuthController> logger)
        {
            _logger = logger;
            _config = config;
        }


        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] SignInUserCommand command, [FromServices] ISender sender, CancellationToken cancellationToken)
        {
            var usr = await sender.Send(command, cancellationToken);

            string token = new AuthenticationHelper().GenerateToken(_config.GetSection("CommumConfigs:TokenSecret").Value, usr.Name, usr.Id);

            _logger.LogInformation($"Usuário autenticado com sucesso em {DateTime.Now}");

            return Ok(token);
        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> PostSignUp([FromBody] SignUpUserCommand command, [FromServices] ISender sender, CancellationToken cancellationToken)
        {
            var usr = await sender.Send(command, cancellationToken);

            _logger.LogInformation($"Usuário criado com sucesso em {DateTime.Now} retorno {JsonSerializer.Serialize(usr)}");

            return Ok(usr);
        }
    }
}
