
namespace SkiNet.WebAPI.Core.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets or sets the criteria.
        /// </summary>
        /// <value>
        /// The criteria.
        /// </value>
        Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Gets the includes.
        /// </summary>
        /// <value>
        /// The includes.
        /// </value>
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
