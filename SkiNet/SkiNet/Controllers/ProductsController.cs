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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SkiNet.WebAPI.Core.Models;
    using SkiNet.WebAPI.Core.Repositories;
    using SkiNet.WebAPI.Core.Specifications;
    using SkiNet.WebAPI.Errors;
    using SkiNet.WebAPI.Helpers;
    using SkiNet.WebAPI.Infrastructure.Data;

    /// <summary>
    /// ProductsController class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        /// <summary>
        /// The product type repo
        /// </summary>
        private readonly IGenericRepository<ProductType> productTypeRepo;

        /// <summary>
        /// The product brand repo
        /// </summary>
        private readonly IGenericRepository<ProductBrand> productBrandRepo;

        /// <summary>
        /// The product repo
        /// </summary>
        private readonly IGenericRepository<Product> productRepo;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController" /> class.
        /// </summary>
        /// <param name="productsRepo">The products repo.</param>
        /// <param name="productBrandRepo">The product brand repo.</param>
        /// <param name="productTypeRepo">The product type repo.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductsController(
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            this.productTypeRepo = productTypeRepo;
            this.productRepo = productsRepo;
            this.productBrandRepo = productBrandRepo;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns>Returns list of products.</returns>
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpecification = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await this.productRepo.CountAsync(spec);

            var products = await this.productRepo.ListAsync(spec);

            var data = this.mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
          
            return this.Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, 
                productParams.PageSize, 
                totalItems, data));
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns a single product.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await this.productRepo.GetEntityWithSpec(spec);

            if (product == null)
            {
                return this.NotFound(new ApiResponse(404));
            }

            return this.Ok(this.mapper.Map<Product, ProductToReturnDto>(product));
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns><see cref="IActionResult"/> list of brands.</returns>
        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await this.productBrandRepo.ListAllAsync();

            return this.Ok();
        }

        /// <summary>
        /// Gets the product types.
        /// </summary>
        /// <returns><see cref="IActionResult"/> list of product brands.</returns>
        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            var types = await this.productTypeRepo.ListAllAsync();

            return this.Ok(types);
        }
    }
}
