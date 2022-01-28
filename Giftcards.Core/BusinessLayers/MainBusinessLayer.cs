using Giftcards.Core.Entities;
using Giftcards.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftcards.Core.BusinessLayers
{
    public class MainBusinessLayer
    {
        private IGiftcardRepository _giftcardRepo;

        public MainBusinessLayer(IGiftcardRepository giftcardRepository)
        {
            _giftcardRepo = giftcardRepository; 
        }


        public IList<Giftcard> FetchAllGiftcards()
        {
            return _giftcardRepo.FetchAll();
        }

        public Response CreateNewGiftcard(Giftcard newGiftcard)
        {
            if (newGiftcard == null)
                return new Response { IsSuccessful = false, Message = "Null entry" };
            if (string.IsNullOrWhiteSpace(newGiftcard.Sender))
                return new Response { IsSuccessful = false, Message = "Missing Sender field" };
            if (string.IsNullOrWhiteSpace(newGiftcard.Recipient))
                return new Response { IsSuccessful = false, Message = "Missing Recipient field" };
            if (newGiftcard.Amount <= 0)
                return new Response { IsSuccessful = false, Message = "Gift amount must be a positive value!" };
            if (newGiftcard.ExpirationDate <= DateTime.Now)
                return new Response { IsSuccessful = false, Message = "Unacceptable expiration date!" };

            _giftcardRepo.CreateGiftcard(newGiftcard);
            return new Response { IsSuccessful = true, Message = "Giftcard successfully created!" };

        }

        public Response DeleteGiftcard(Giftcard giftcard)
        {
            if (giftcard == null)
                return new Response { IsSuccessful = false, Message = "Null entry" };

            Giftcard existingGiftcard = _giftcardRepo.FetchAll().Where(x => x.Id.Equals(giftcard.Id)).SingleOrDefault();
            if (existingGiftcard == null)
                return new Response { IsSuccessful = false, Message = $"The requested card with Id {giftcard.Id} doesn't exisit!" };

            _giftcardRepo.DeleteGiftcard(existingGiftcard);
            return new Response { IsSuccessful = true, Message = $"Giftcard with Id {existingGiftcard.Id} successfully deleted" };
        }
    }
}
