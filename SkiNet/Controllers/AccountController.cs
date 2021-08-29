using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkiNet.WebAPI.Core.Models.Identity;
using SkiNet.WebAPI.Core.Services;
using SkiNet.WebAPI.Errors;
using SkiNet.WebAPI.Extensions;
using SkiNet.WebAPI.Models.DTOs;

namespace SkiNet.WebAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> userManager;

        private readonly SignInManager<AppUser> signInManager;

        private readonly ITokenService tokenService;

        private readonly IMapper mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await this.userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

            return this.Ok(new UserDto
            {
                Email = user.Email,
                Token = this.tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            });
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return this.Ok(await this.userManager.FindByEmailAsync(email) != null);
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<bool>> GetUserAddress()
        {
            var user = await this.userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

            return this.Ok(this.mapper.Map<Address, AddressDto>(user.Address));
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<IActionResult> UpdateUserAddress(AddressDto address)
        {
            var user = await this.userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            user.Address = this.mapper.Map<AddressDto, Address>(address);

            var result = await this.userManager.UpdateAsync(user);

            if (result.Succeeded == true)
            {
                return this.Ok(this.mapper.Map<Address, AddressDto>(user.Address));
            }

            return this.BadRequest("Something went wrong while updating address!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await this.userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return this.Unauthorized(new ApiResponse(401));
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return this.Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {

                return new BadRequestObjectResult(new ApiValidationErrorResponse
                {
                    Errors = new[] { "Email address is in use" }
                });
            }
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded == false)
            {
                return this.BadRequest(new ApiResponse(400));
            }

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = tokenService.CreateToken(user),
                Email = user.Email
            };
        }

    }
}
