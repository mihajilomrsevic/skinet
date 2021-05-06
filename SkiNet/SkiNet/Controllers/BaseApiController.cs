//-------------------------------------------------------------------------------
// <copyright file="BaseApiController.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
namespace SkiNet.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Base controller made for mandatory settings of controllers.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
