//-------------------------------------------------------------------------------
// <copyright file="ProductRepository.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using SkiNet.WebAPI.Core.Models;
    using SkiNet.WebAPI.Core.Repositories;
    using SkiNet.WebAPI.Infrastructure.Data;

    /// <summary>
    /// ProductRepository implementation.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Core.Repositories.IProductRepository" />
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly StoreContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the product brands asynchronous.
        /// </summary>
        /// <returns>List of product brands.</returns>
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await this.context.ProductBrands.ToListAsync();
        }

        /// <summary>
        /// Gets the product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product by ID.</returns>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await this.context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Gets the products asynchronous.
        /// </summary>
        /// <returns>List of products.</returns>
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await this.context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the product types asynchronous.
        /// </summary>
        /// <returns>List of products types.</returns>
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await this.context.ProductTypes.ToListAsync();
        }
    }
}