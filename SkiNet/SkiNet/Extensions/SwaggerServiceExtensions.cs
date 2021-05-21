//-------------------------------------------------------------------------------
// <copyright file="SwaggerServiceExtensions.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extension class made for injecting swagger service.
    /// </summary>
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Adds the swagger documentation.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns><see cref="IServiceCollection"/> swagger service.</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkiNet", Version = "v1" });
            });

            return services;
        }

        /// <summary>
        /// Users the swagger documentation.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns><see cref="IApplicationBuilder"/> swagger instance.</returns>
        public static IApplicationBuilder UserSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkiNet v1"));

            return app;
        }
    }
}