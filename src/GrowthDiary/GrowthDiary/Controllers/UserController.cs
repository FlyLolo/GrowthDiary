using GrowthDiary.IService;
using GrowthDiary.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthDiary.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            
            return _userService.FindAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        public JsonResult Post([FromBody] UserViewModel user)
        {
            var result = 0;
            _userService.InsertOneAsync(user);
            if (result == 1)
            {
                return new JsonResult(new { a = 1 });
            }
            else
            {
                return new JsonResult(new { a = 1 });
            }
            
        }
    }
}
