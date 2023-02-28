using FullCardNumber.Core.CardAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCardNumber.Infrastruture.Data.Config
{
    public class UsersAuthConfiguration : IEntityTypeConfiguration<UsersAuth>
    {
        public void Configure(EntityTypeBuilder<UsersAuth> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
          
        }
    }
}
