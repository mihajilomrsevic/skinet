
namespace SkiNet.WebAPI.Core.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class BaseSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSpecification{T}"/> class.
        /// </summary>
        public BaseSpecification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSpecification{T}"/> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            this.Criteria = criteria;
        }

        /// <summary>
        /// Gets the criteria.
        /// </summary>
        /// <value>
        /// The criteria.
        /// </value>
        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Gets the includes.
        /// </summary>
        /// <value>
        /// The includes.
        /// </value>
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        /// <summary>
        /// Adds the include.
        /// </summary>
        /// <param name="includeExpression">The include expression.</param>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}