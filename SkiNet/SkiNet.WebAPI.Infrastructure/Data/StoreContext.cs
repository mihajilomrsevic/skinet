//-------------------------------------------------------------------------------
// <copyright file="StoreContext.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using SkiNet.WebAPI.Core.Models;

    /// <summary>
    /// StoreContext class for manipulating database.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class StoreContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public DbSet<Product> Products { get; set; }
    }
}
