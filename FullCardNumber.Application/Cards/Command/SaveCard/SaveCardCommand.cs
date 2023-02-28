using FullCardNumber.Application.UsersAuth.Command.SignIn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Application.Cards.Command.SaveCard
{
    public class SaveCardCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        internal int IdUser { get; set; }

        public void SetIdUser(int idUser)
        {
            IdUser = idUser;
        }

    }
}
