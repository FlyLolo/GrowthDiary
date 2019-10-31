using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrowthDiary.Controllers
{
    [Authorize(Policy = "Permission")]
    public class BaseController : Controller
    {
    }
}
