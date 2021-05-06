//-------------------------------------------------------------------------------
// <copyright file="BuggyController.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
namespace SkiNet.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkiNet.WebAPI.Errors;
    using SkiNet.WebAPI.Infrastructure.Data;

    /// <summary>
    /// Controller made for testing purposes.
    /// </summary>
    /// <seealso cref="SkiNet.WebAPI.Controllers.BaseApiController" />
    public class BuggyController : BaseApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly StoreContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuggyController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BuggyController(StoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the not found request.
        /// </summary>
        /// <returns><see cref="IActionResult"/> response</returns>
        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = this.context.Products.Find(42);

            if (thing == null)
            {
                return this.NotFound(new ApiResponse(404));
            }

            return this.Ok(thing);
        }

        /// <summary>
        /// Gets the server error.
        /// </summary>
        /// <returns><see cref="IActionResult"/> response</returns>
        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            var thing = this.context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return this.Ok();
        }

        /// <summary>
        /// Gets the bad request.
        /// </summary>
        /// <returns><see cref="IActionResult"/> response.</returns>
        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return this.BadRequest(new ApiResponse(400));
        }

        /// <summary>
        /// Gets the not found request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IActionResult"/> response.</returns>
        [HttpGet("badrequest/{id}")]
        public IActionResult GetNotFoundRequest(int id)
        {
            return this.Ok();
        }
    }
}
