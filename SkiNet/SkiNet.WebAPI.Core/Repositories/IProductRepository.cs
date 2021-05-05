namespace SkiNet.WebAPI.Core.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SkiNet.WebAPI.Core.Models;

    public interface IProductRepository
    {
        /// <summary>
        /// Gets the product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Gets the products asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductsAsync();

        /// <summary>
        /// Gets the product brands asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        /// <summary>
        /// Gets the product types asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
