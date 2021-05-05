using System.Collections.Generic;
using System.Threading.Tasks;
using SkiNet.WebAPI.Core.Models;
using SkiNet.WebAPI.Core.Specifications;

namespace SkiNet.WebAPI.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Lists all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Gets the entity with spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        /// <summary>
        /// Lists the asynchronous.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
