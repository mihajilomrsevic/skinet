//-------------------------------------------------------------------------------
// <copyright file="SpecificationEvaluator.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Infrastructure.Data
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SkiNet.WebAPI.Core.Models;
    using SkiNet.WebAPI.Core.Specifications;

    /// <summary>
    /// SpecificationEvaluator model.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <param name="inputQuery">The input query.</param>
        /// <param name="spec">The spec.</param>
        /// <returns>Returns a <see cref="IQueryable{TEntity}"/> query.</returns>
        public static IQueryable<TEntity> GetQuery(
            IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
