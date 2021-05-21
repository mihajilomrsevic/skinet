//-------------------------------------------------------------------------------
// <copyright file="ISpecification.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// ISpecification interface.
    /// </summary>
    /// <typeparam name="T">Object of choice.</typeparam>
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

        /// <summary>
        /// Gets the order by.
        /// </summary>
        /// <value>
        /// The order by.
        /// </value>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// Gets the order by descending.
        /// </summary>
        /// <value>
        /// The order by descending.
        /// </value>
        Expression<Func<T, object>> OrderByDescending { get; }

        /// <summary>
        /// Gets the take.
        /// </summary>
        /// <value>
        /// The take.
        /// </value>
        int Take { get; }

        /// <summary>
        /// Gets the skip.
        /// </summary>
        /// <value>
        /// The skip.
        /// </value>
        int Skip { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is paging enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is paging enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsPagingEnabled { get; }
    }
}