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

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
