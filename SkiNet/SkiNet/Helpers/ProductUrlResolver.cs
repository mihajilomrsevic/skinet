//-------------------------------------------------------------------------------
// <copyright file="ProductUrlResolver.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Helpers
{
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using SkiNet.WebAPI.Core.Models;

    /// <summary>
    /// ProductUrlResolver class made to create URL for products, actually for pictures.
    /// </summary>
    /// <seealso cref="AutoMapper.IValueResolver{SkiNet.WebAPI.Core.Models.Product, SkiNet.WebAPI.Core.Models.ProductToReturnDto, System.String}" />
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductUrlResolver" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public ProductUrlResolver(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Implementors use source object to provide a destination object.
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object, if exists</param>
        /// <param name="destMember">Destination member</param>
        /// <param name="context">The context of the mapping</param>
        /// <returns>
        /// Result, typically build from the source resolution result
        /// </returns>
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return this.config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}