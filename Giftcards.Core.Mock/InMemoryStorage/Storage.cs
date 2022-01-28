using Giftcards.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftcards.Core.Mock.InMemoryStorage
{
    public static class Storage
    {
        public static IList<Giftcard> Giftcards { get; set; }

        public static void InitializeMemory()
        {
            Giftcards = new List<Giftcard>();

            Giftcards.Add(new Giftcard()
            {
                Id = 1,
                Sender = "Mario",
                Recipient = "Mirella",
                Message = "Buon anniversario!!",
                Amount = 100,
                ExpirationDate = new DateTime(2022, 05, 01)
            });

            Giftcards.Add(new Giftcard()
            {
                Id=2,
                Sender = "Iva",
                Recipient = "Sara",
                Message = "Per la mia nipote preferita",
                Amount = 50,
                ExpirationDate = new DateTime(2022, 03, 20)
            });

            Giftcards.Add(new Giftcard()
            {
                Id = 3,
                Sender = "Stefano",
                Recipient = "Andrea",
                Message = "Tanti auguri <3",
                Amount = 80,
                ExpirationDate = new DateTime(2022, 4, 10)
            });
        }
    }
}
