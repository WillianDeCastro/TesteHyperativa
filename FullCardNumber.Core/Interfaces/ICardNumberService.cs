using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Core.Interfaces
{
    public interface ICardNumberService
    {
        Task<int> AddCardAsync(string name, string number,int idUser);
    }
}
