//-------------------------------------------------------------------------------
// <copyright file="ApiValidationErrorResponse.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Errors
{
    using System.Collections.Generic;

    /// <summary>
    /// Custom validation for errors.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Errors.ApiResponse" />
    public class ApiValidationErrorResponse : ApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiValidationErrorResponse"/> class.
        /// </summary>
        public ApiValidationErrorResponse() : base(400)
        {
        }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<string> Errors { get; set; }
    }
}