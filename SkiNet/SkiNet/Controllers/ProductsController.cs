//-------------------------------------------------------------------------------
// <copyright file="ProductsController.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SkiNet.WebAPI.Infrastructure.Data;

    /// <summary>
    /// ProductsController class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly StoreContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductsController(StoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns>Returns list of products.</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await this.context.Products.ToListAsync();

            return this.Ok(products);
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a single product.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var products = await this.context.Products.FindAsync(id);

            return this.Ok(products);
        }
    }
}
