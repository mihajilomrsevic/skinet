using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkiNet.WebAPI.Core.Models;
using SkiNet.WebAPI.Infrastructure.Data;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../SkiNet.WebAPI.Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        foreach (var item in brands)
                        {
                            context.ProductBrands.Add(item);
                        }
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands ON;");
                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../SkiNet.WebAPI.Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        foreach (var item in types)
                        {
                            context.ProductTypes.Add(item);
                        }
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes ON;");

                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../SkiNet.WebAPI.Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        foreach (var item in products)
                        {
                            context.Products.Add(item);
                        }
                       // context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON;");

                        await context.SaveChangesAsync();
                        transaction.Commit();

                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}