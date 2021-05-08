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
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams) : base(x =>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
        (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            this.AddInclude(x => x.ProductType);
            this.AddInclude(x => x.ProductBrand);
            this.AddOrderBy(x => x.Name);
            this.ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
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