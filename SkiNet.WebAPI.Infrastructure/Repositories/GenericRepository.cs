//-------------------------------------------------------------------------------
// <copyright file="GenericRepository.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using global::Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using SkiNet.WebAPI.Core.Models;
    using SkiNet.WebAPI.Core.Repositories;
    using SkiNet.WebAPI.Core.Specifications;
    using SkiNet.WebAPI.Infrastructure.Data;

    /// <summary>
    /// GenericRepository implementation.
    /// </summary>
    /// <typeparam name="T">Object of choice.</typeparam>
    /// <seealso cref="SkiNet.WebAPI.Core.Repositories.IGenericRepository{T}" />
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly StoreContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(StoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await this.ApplySpecification(spec).CountAsync();
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a object by ID.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Gets the entity with spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns><see cref="Task{T}"/> specification.</returns>
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await this.ApplySpecification(spec).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Lists all asynchronous.
        /// </summary>
        /// <returns>List of objects <see cref="IReadOnlyCollection{T}"/></returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Lists the asynchronous.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns><see cref="IReadOnlyCollection{T}"/></returns>
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await this.ApplySpecification(spec).ToListAsync();
        }

        /// <summary>
        /// Applies the specification.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns><see cref="SpecificationEvaluator"/></returns>
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(this.context.Set<T>().AsQueryable(), spec);
        }
    }
}