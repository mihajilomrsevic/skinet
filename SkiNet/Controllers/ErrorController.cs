//-------------------------------------------------------------------------------
// <copyright file="ErrorController.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using SkiNet.WebAPI.Errors;

namespace SkiNet.WebAPI.Controllers
{

    /// <summary>
    /// Controller which defines server error behavior.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Controllers.BaseApiController" />
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}