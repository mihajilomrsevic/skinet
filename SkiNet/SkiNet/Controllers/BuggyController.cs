using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkiNet.WebAPI.Errors;
using SkiNet.WebAPI.Infrastructure.Data;

namespace SkiNet.WebAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
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
        /// <returns></returns>
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

        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            var thing = this.context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return this.Ok();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return this.BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetNotFoundRequest(int id)
        {
            return this.Ok();
        }
    }
}
