//-------------------------------------------------------------------------------
// <copyright file="IProductRepository.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SkiNet.WebAPI.Core.Models;

    /// <summary>
    /// IProductRepository interface.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product by ID.</returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Gets the products asynchronous.
        /// </summary>
        /// <returns>List of products.</returns>
        Task<IReadOnlyList<Product>> GetProductsAsync();

        /// <summary>
        /// Gets the product brands asynchronous.
        /// </summary>
        /// <returns>Product brands.</returns>
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        /// <summary>
        /// Gets the product types asynchronous.
        /// </summary>
        /// <returns>Product types.</returns>
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
