using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkiNet.WebAPI.Core.Models;
using SkiNet.WebAPI.Core.Repositories;
using SkiNet.WebAPI.Models.DTOs;

namespace SkiNet.WebAPI.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket = await this.basketRepository.GetBasketAsync(id);

            return this.Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = this.mapper.Map<CustomerBasketDto, CustomerBasket>(basket);

            var updatedBasket = await this.basketRepository.UpdateBasketAsync(customerBasket);

            return this.Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await this.basketRepository.DeleteBasketAsync(id);
        }
    }
}
