//-------------------------------------------------------------------------------
// <copyright file="ProductType.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Models
{
    /// <summary>
    /// ProductType model.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Core.Models.BaseEntity" />
    public class ProductType : BaseEntity
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
