using Microsoft.AspNetCore.Mvc;
using SkiNet.WebAPI.Errors;

namespace SkiNet.WebAPI.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        public ErrorController()
        {
        }

        /// <summary>
        /// Errors the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
