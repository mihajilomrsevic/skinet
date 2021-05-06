//-------------------------------------------------------------------------------
// <copyright file="ProductBrand.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Models
{
    /// <summary>
    /// ProductBrand model.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Core.Models.BaseEntity" />
    public class ProductBrand : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
