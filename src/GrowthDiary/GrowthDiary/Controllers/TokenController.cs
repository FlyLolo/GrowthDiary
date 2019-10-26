using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FlyLolo.JWT;
using GrowthDiary.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthDiary.Controllers
{
    [Route("Token")]
    public class TokenController : BaseController
    {
        private readonly ITokenHelper tokenHelper;
        public TokenController(ITokenHelper _tokenHelper)
        {
            tokenHelper = _tokenHelper;
        }

        [HttpGet]
        public ApiResult Get()
        {
            return new ApiResult<Token>(tokenHelper.RefreshToken(Request.HttpContext.User),ReturnCode.Success);
        }
    }
}
