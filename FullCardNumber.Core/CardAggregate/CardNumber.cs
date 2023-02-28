using FullCardNumber.SharedKernel;

namespace FullCardNumber.Core.CardAggregate
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Batch { get; set; }
        public string Number { get; set; }
        public int UsersAuthId { get; set; }
        public virtual UsersAuth UsersAuth { get; set; }
    }
}
