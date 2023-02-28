using FullCardNumber.Core.CardAggregate;
using FullCardNumber.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace FullCardNumber.Api
{
    public static class SeedData
    {
        public static readonly UsersAuth UsersAuth = new UsersAuth("willian", "teste@4556");
        public static readonly Card card1 = new Card
        {
            Name = "willian teste",
            UsersAuth = UsersAuth,
            Number = "1254".PadRight(14, '0'),
            Batch = new string('w', 5),
            Date = DateTime.Now
        };
        public static readonly Card card2 = new Card
        {
            Name = "willian teste",
            UsersAuth = UsersAuth,
            Number = "1111".PadRight(14, '0'),
            Batch = new string('w', 5),
            Date = DateTime.Now
        };

        public static readonly Card card3 = new Card
        {
            Name = "willian teste",
            UsersAuth = UsersAuth,
            Number = "2222".PadRight(14, '0'),
            Batch = new string('w', 5),
            Date = DateTime.Now
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new CardDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CardDbContext>>(), null))
            {
                if (dbContext.Cards.Any())
                {
                    return;
                }

                PopulateTestData(dbContext);
            }
        }
        public static void PopulateTestData(CardDbContext dbContext)
        {
            foreach (var item in dbContext.UsersAuths)
            {
                dbContext.Remove(item);
            }
            foreach (var item in dbContext.Cards)
            {
                dbContext.Remove(item);
            }

            dbContext.SaveChanges();

            UsersAuth.Cards.Add(card1);
            UsersAuth.Cards.Add(card2);
            UsersAuth.Cards.Add(card3);
            dbContext.UsersAuths.Add(UsersAuth);

            dbContext.SaveChanges();
        }
    }
}
