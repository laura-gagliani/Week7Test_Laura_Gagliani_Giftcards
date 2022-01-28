using Giftcards.Core.Entities;
using Giftcards.Core.Mock.InMemoryStorage;
using Giftcards.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftcards.Core.Mock.Repositories
{
    public class MockGiftcardRepository : IGiftcardRepository
    {
        public IList<Giftcard> FetchAll()
        {
            return Storage.Giftcards;
        }

        public void CreateGiftcard(Giftcard newGiftcard)
        {
            if (newGiftcard == null)
                throw new ArgumentNullException(nameof(newGiftcard));

            //la card è passata senza id; glielo aggiungo qui

            if (Storage.Giftcards.Count == 0)
                newGiftcard.Id = 1;

            else
            {
                int maxId = Storage.Giftcards.Max(x => x.Id);
                newGiftcard.Id = maxId + 1;
            }               

            Storage.Giftcards.Add(newGiftcard);
            
        }

        public void DeleteGiftcard(Giftcard giftcardToDelete)
        {
            if (giftcardToDelete == null)
                throw new ArgumentNullException(nameof (giftcardToDelete));

            //controllo che sia in memoria
            Giftcard existentGiftcard = Storage.Giftcards.Where( x => x.Id.Equals(giftcardToDelete.Id) ).SingleOrDefault();

            if (existentGiftcard == null)
                throw new InvalidOperationException();

            Storage.Giftcards.Remove(giftcardToDelete);

        }


        public void UpdateGiftcard(Giftcard updatedGiftcard)
        {
            Giftcard existingCard = Storage.Giftcards.SingleOrDefault(x => x.Id == updatedGiftcard.Id); 

            Storage.Giftcards.Remove(existingCard);
            Storage.Giftcards.Add(updatedGiftcard);
        }
    }
}
