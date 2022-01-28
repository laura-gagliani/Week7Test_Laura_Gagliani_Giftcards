using Giftcards.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftcards.Core.RepositoryInterface
{
    public interface IGiftcardRepository
    {
        IList<Giftcard> FetchAll();

        void CreateGiftcard(Giftcard newGiftcard);
        void UpdateGiftcard(Giftcard updatedGiftcard);
        void DeleteGiftcard(Giftcard giftcardToDelete);
    }
}
