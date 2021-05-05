//-------------------------------------------------------------------------------
// <copyright file="StoreContext.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Infrastructure.Data
{
    using System.Reflection;
    using global::SkiNet.WebAPI.Core.Models;
    using Microsoft.EntityFrameworkCore;


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

        /// <summary>
        /// Gets or sets the product brands.
        /// </summary>
        /// <value>
        /// The product brands.
        /// </value>
        public DbSet<ProductBrand> ProductBrands { get; set; }

        /// <summary>
        /// Gets or sets the product types.
        /// </summary>
        /// <value>
        /// The product types.
        /// </value>
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
