using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrowthDiary.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
