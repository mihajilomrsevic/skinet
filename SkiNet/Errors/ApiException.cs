//-------------------------------------------------------------------------------
// <copyright file="ApiException.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Errors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Custom exception class.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Errors.ApiResponse" />
    public class ApiException : ApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        public ApiException(
            int statusCode,
            string message = null,
            string details = null) : base(statusCode, message)
        {
            this.Details = details;
        }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string Details { get; set; }
    }
}