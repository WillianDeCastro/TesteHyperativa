using MediatR;

namespace FullCardNumber.Application.UsersAuth.Command.SignIn
{
    public class SignInUserCommand: IRequest<SignInUserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public record SignInUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
