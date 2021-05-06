//-------------------------------------------------------------------------------
// <copyright file="ProductToReturnDto.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Models
{
    /// <summary>
    /// ProductToReturn class to transfer a data between layers.
    /// </summary>
    public class ProductToReturnDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
        public string ProductType { get; set; }

        /// <summary>
        /// Gets or sets the product brand.
        /// </summary>
        /// <value>
        /// The product brand.
        /// </value>
        public string ProductBrand { get; set; }
    }
}
