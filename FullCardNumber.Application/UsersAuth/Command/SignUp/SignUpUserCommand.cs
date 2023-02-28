using MediatR;

namespace FullCardNumber.Application.UsersAuth.Command.SignUp
{

    public class SignUpUserCommand : IRequest<SignUpUserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public record SignUpUserResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
    }
}
