using FullCardNumber.Core.CardAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Infrastruture.Data.Config
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Number).IsRequired().IsFixedLength().HasMaxLength(18);
            builder.HasOne(c => c.UsersAuth).WithMany(u => u.Cards).HasForeignKey(c => c.UsersAuthId);
        }
    }
}
