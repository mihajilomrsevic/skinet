using System.Threading.Tasks;
using SkiNet.WebAPI.Core.Models;

namespace SkiNet.WebAPI.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string basketId);
    }
}
