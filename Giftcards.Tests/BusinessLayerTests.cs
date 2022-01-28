using Giftcards.Core.BusinessLayers;
using Giftcards.Core.Entities;
using Giftcards.Core.Mock.InMemoryStorage;
using Giftcards.Core.Mock.Repositories;
using System;
using Xunit;

namespace Giftcards.Tests
{
    public class BusinessLayerTests
    {
        [Fact]
        public void ShouldCreateGiftcard()
        {
            //arrange
            Storage.InitializeMemory();
            MainBusinessLayer bl = new MainBusinessLayer(new MockGiftcardRepository());

            Giftcard giftcard = new Giftcard()
            {
                Sender = "tizio",
                Recipient = "caio",
                Message = "prova",
                Amount = 100,
                ExpirationDate = new DateTime(2022, 05, 01)
            };

            //act
            int initialCount = Storage.Giftcards.Count;
            bl.CreateNewGiftcard(giftcard);
            int finalCount = Storage.Giftcards.Count;

            //assert
            Assert.Equal(finalCount, initialCount+1);

        }
    }
}
