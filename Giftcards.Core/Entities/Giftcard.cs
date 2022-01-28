using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftcards.Core.Entities
{
    public class Giftcard
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
        public double Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

}
