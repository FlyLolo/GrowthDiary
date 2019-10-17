using GrowthDiary.Common;
using GrowthDiary.IService;
using GrowthDiary.Model;
using GrowthDiary.Wx;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthDiary.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly WXOptions _options;
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IOptionsMonitor<WXOptions> options, IUserService userService, ILogger<AccountController> logger)
        {
            _logger = logger;
            _options = options.Get("WXOptions");
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get([FromServices] IHttpClientFactory httpClientFactory)
        {
            string loginCode;
            if (Request.Query.Keys.Contains("loginCode"))
            {
                loginCode = Request.Query["loginCode"];

                if (string.IsNullOrEmpty(loginCode))
                {
                    return new JsonResult(new ApiResult(ReturnCode.ArgsError));
                }
            }
            else
            {
                return new JsonResult(new ApiResult(ReturnCode.ArgsError));
            }

            Code2Session session = null;
            string url = string.Format(_options.Code2Session, _options.AppId, _options.Secret, loginCode);

            using (var client = httpClientFactory.CreateClient())
            {
                using var res = client.GetAsync(url);
                if (res.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var str = res.Result.Content.ReadAsStringAsync().Result;
                    session = JsonConvert.DeserializeObject<Code2Session>(str);
                }
            }

            if (string.IsNullOrEmpty(session.Openid))
            {
                return new JsonResult(new ApiResult(ReturnCode.GeneralError));
            }

            UserViewModel user = _userService.Find(new UserSearchModel() { WxOpenId = session.Openid });

            if (null == user)
            {
                if (Request.Query.Keys.Contains("nickName"))
                {
                    user = new UserViewModel
                    {
                        NickName = Request.Query["nickName"],
                        Gender = Request.Query["gender"],
                        Country = Request.Query["country"],
                        Province = Request.Query["province"],
                        City = Request.Query["city"],
                        Language = Request.Query["language"],

                        UserCode = session.Openid,
                        WxOpenId = session.Openid
                    };
                    user.AvatarUrl = Request.Query["avatarUrl"];
                    user.State = 2;
                    try
                    {
                        _userService.InsertOneAsync(user);
                        return new JsonResult(new ApiResult<UserViewModel>(user, ReturnCode.Success));
                    }
                    catch (System.Exception)
                    {
                        return new JsonResult(new ApiResult(ReturnCode.GeneralError));
                    }
                }
                else
                {
                    return new JsonResult(new ApiResult(ReturnCode.ArgsError));
                }
            }

            return new JsonResult(new ApiResult<UserViewModel>(user,ReturnCode.Success));
        }
    }
}
