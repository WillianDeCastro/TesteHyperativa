using FullCardNumber.Application.Cards.Command.SaveCard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Application.Cards.Command.BatchSaveCard
{
    public class BatchSaveCardCommand:IRequest<IEnumerable<int>>
    {
        public List<SaveCardCommand> Cards { get; set; }
    }
}
