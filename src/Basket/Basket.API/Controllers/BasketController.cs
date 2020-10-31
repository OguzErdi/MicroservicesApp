using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //to say that this method will return these
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> GetBasketAsync(string userName)
        {
            var basket = await _repository.GetBasket(userName);

            //if user first acces, should see an empty basket.
            BasketCart response = basket ?? new BasketCart(userName);
            
            //cover response with Http Verbs
            return base.Ok(response);
        }

        [HttpPost]
        //to say that this method will return these
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> UpdateBasketAsync([FromBody] BasketCart basketCart)
        {
            return Ok(await _repository.UpdateBasket(basketCart));
        }

        //to say that provide userName param
        [HttpDelete("{userName}")]
        //to say that this method will return these
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasketAsync(string userName)
        {
            return Ok(await _repository.DeleteBasket(userName));
        }
    }
}
