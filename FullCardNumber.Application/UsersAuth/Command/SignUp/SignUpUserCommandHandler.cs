using FullCardNumber.Application.UsersAuth.Command.SignIn;
using FullCardNumber.Core.Interfaces;
using MediatR;

namespace FullCardNumber.Application.UsersAuth.Command.SignUp
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, SignUpUserResponse>
    {
        private readonly IAuthService _authService;
        public SignUpUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<SignUpUserResponse> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var userResponse = new SignUpUserResponse
            {
                Success = false,
            };

            var user = await _authService.CreateUserAsync(request.UserName, request.Password);

            if (user is not null)
            {
                userResponse.Name = user.Name;
                userResponse.Success =true;
            }

            return userResponse;
        }
    }

}
