using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    //name it BasketCart because may have confilict with Basket Enum Name 
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();

        public BasketCart()
        {
        }

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                Items.ForEach(x => totalPrice += x.Price * x.Quantitiy);

                return totalPrice;
            }
        }

    }
}
