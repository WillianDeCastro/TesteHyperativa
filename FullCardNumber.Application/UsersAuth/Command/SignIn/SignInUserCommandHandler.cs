using FullCardNumber.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Application.UsersAuth.Command.SignIn
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, SignInUserResponse>
    {
        private readonly IAuthService _authService;
        public SignInUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<SignInUserResponse> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            SignInUserResponse userResponse = new();

            var user = await _authService.SignInAsync(request.UserName, request.Password);

            if (user is not null)
            {
                userResponse.Name = user.Name;
                userResponse.Id = user.Id;
            }

            return userResponse;
        }
    }
}
