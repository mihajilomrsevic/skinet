using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiNet.WebAPI.Core.Models.Identity;

namespace SkiNet.WebAPI.Core.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
