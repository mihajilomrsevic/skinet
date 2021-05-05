using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using SkiNet.WebAPI.Core.Models;

namespace SkiNet.WebAPI.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductUrlResolver"/> class.
        /// </summary>
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
