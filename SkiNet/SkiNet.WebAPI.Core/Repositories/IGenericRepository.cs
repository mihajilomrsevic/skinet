//-------------------------------------------------------------------------------
// <copyright file="IGenericRepository.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SkiNet.WebAPI.Core.Models;
    using SkiNet.WebAPI.Core.Specifications;

    /// <summary>
    /// Interface repository made for 
    /// </summary>
    /// <typeparam name="T">Object of choice.</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="Task{T}"/>Object by ID.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Lists all asynchronous.
        /// </summary>
        /// <returns><see cref="IReadOnlyList{T}"/> of objects.</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Gets the entity with spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns><see cref="Task{T}"/> specification.</returns>
        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        /// <summary>
        /// Lists the asynchronous.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of specifications.</returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
