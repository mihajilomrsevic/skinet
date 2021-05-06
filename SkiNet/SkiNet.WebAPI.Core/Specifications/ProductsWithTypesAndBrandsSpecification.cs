//-------------------------------------------------------------------------------
// <copyright file="ProductsWithTypesAndBrandsSpecification.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Specifications
{
    using SkiNet.WebAPI.Core.Models;

    /// <summary>
    /// ProductsWithTypesAndBrandsSpecification model.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Core.Specifications.BaseSpecification{SkiNet.WebAPI.Core.Models.Product}" />
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsWithTypesAndBrandsSpecification" /> class.
        /// </summary>
        public ProductsWithTypesAndBrandsSpecification()
        {
            this.AddInclude(x => x.ProductType);
            this.AddInclude(x => x.ProductBrand);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsWithTypesAndBrandsSpecification"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            this.AddInclude(x => x.ProductType);
            this.AddInclude(x => x.ProductBrand);
        }
    }
}
