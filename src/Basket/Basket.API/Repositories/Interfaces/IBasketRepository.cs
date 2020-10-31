using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketCart">
        /// a key-value pair which is key should be userName and value should be whole basket object as json object
        /// </param>
        /// <returns>
        /// the updated basketCart value
        /// </returns>
        Task<BasketCart> UpdateBasket(BasketCart basketCart);
        Task<bool> DeleteBasket(string userName);
    }
}
