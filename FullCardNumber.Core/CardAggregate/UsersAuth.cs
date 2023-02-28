using FullCardNumber.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Core.CardAggregate
{
    public class UsersAuth : BaseEntity
    {
        public UsersAuth()
        {

        }
        public UsersAuth(string name, string password)
        {
            Name=name;
            Password=password;
        }

        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Card> Cards { get; } = new List<Card>();
    }
}
