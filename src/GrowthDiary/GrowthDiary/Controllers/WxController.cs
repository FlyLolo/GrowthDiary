using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowthDiary.Wx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthDiary.Controllers
{
    [Route("api/[controller]")]
    public class WxController : Controller
    {
        private readonly IConfiguration _configuration;
        public WxController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get(SignatureModel signatureModel)
        {
            signatureModel.Token = _configuration["WX:Token"];
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
