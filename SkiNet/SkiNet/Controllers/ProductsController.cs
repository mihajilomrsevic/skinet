//-------------------------------------------------------------------------------
// <copyright file="ProductsController.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SkiNet.WebAPI.Core.Models;
    using SkiNet.WebAPI.Core.Repositories;
    using SkiNet.WebAPI.Core.Specifications;
    using SkiNet.WebAPI.Infrastructure.Data;

    /// <summary>
    /// ProductsController class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> productTypeRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<Product> productRepo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productyTypeRepo,
            IMapper mapper)
        {
            this.productTypeRepo = productyTypeRepo;
            this.productRepo = productsRepo;
            this.productBrandRepo = productBrandRepo;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns>Returns list of products.</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await this.productRepo.ListAsync(spec);

            return this.Ok(this.mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a single product.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await this.productRepo.GetEntityWithSpec(spec);

            return this.Ok(this.mapper.Map<Product, ProductToReturnDto>(product));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await this.productBrandRepo.ListAllAsync();

            return this.Ok();
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            var types = await this.productTypeRepo.ListAllAsync();

            return this.Ok(types);
        }
    }
}
