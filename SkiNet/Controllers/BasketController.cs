using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkiNet.WebAPI.Core.Models;
using SkiNet.WebAPI.Core.Repositories;

namespace SkiNet.WebAPI.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository basketRepository;
        public BasketController(IBasketRepository basketRepository) 
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket = await this.basketRepository.GetBasketAsync(id);

            return this.Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await this.basketRepository.UpdateBasketAsync(basket);

            return this.Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await this.basketRepository.DeleteBasketAsync(id);
        }
    }
}
