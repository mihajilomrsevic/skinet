//-------------------------------------------------------------------------------
// <copyright file="Product.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Models
{
    /// <summary>
    /// Product model.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the picture URL.
        /// </summary>
        /// <value>
        /// The picture URL.
        /// </value>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        /// <value>
        /// The type of the product.
        /// </value>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Gets or sets the product type identifier.
        /// </summary>
        /// <value>
        /// The product type identifier.
        /// </value>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the product brand.
        /// </summary>
        /// <value>
        /// The product brand.
        /// </value>
        public ProductBrand ProductBrand { get; set; }

        /// <summary>
        /// Gets or sets the product brand identifier.
        /// </summary>
        /// <value>
        /// The product brand identifier.
        /// </value>
        public int ProductBrandId { get; set; }
    }
}