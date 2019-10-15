using GrowthDiary.Common;
using GrowthDiary.Wx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthDiary.Controllers
{
    [Route("api/[controller]")]
    public class WxController : Controller
    {
        private readonly IOptionsMonitor<WXOptions> _options;
        public WxController(IOptionsMonitor<WXOptions> options)
        {
            _options = options;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get(SignatureModel signatureModel)
        {
            signatureModel.Token = _options.Get("WXOptions").Token;
            string rtnStr;
            if (SignatureHelper.Check(signatureModel))
            {
                rtnStr = signatureModel.Echostr;
            }
            else
            {
                rtnStr = signatureModel.Signature + signatureModel.Timestamp + signatureModel.Nonce + signatureModel.Echostr;
            }
            return Content(rtnStr);
        }
    }
}
