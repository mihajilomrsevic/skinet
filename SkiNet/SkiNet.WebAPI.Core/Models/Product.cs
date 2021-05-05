﻿//-------------------------------------------------------------------------------
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

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }
    }
}
