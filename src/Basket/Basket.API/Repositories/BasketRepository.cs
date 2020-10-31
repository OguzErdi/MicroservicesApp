using Basket.API.Data.Interfaces;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _context;

        public BasketRepository(IBasketContext context)
        {
            _context = context;
        }

        //to perform lazy loading use Task
        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = await _context.Redis.StringGetAsync(userName);

            if (basket.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basketCart)
        {
            string jsonBasketCart = JsonConvert.SerializeObject(basketCart);
            var isUpdated = await _context.Redis.StringSetAsync(basketCart.UserName, jsonBasketCart);

            if (!isUpdated)
            {
                return null;
            }

            return await GetBasket(basketCart.UserName);
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            return await _context.Redis.KeyDeleteAsync(userName);
        }
    }
}
