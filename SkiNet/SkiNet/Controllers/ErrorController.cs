//-------------------------------------------------------------------------------
// <copyright file="ErrorController.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkiNet.WebAPI.Errors;

    /// <summary>
    /// Controller which defines server error behavior.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Controllers.BaseApiController" />
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorController"/> class.
        /// </summary>
        public ErrorController()
        {
        }

        /// <summary>
        /// Errors the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns><see cref="IActionResult"/> response.</returns>
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
