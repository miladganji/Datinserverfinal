using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datin.Api.Data;
using Datin.Api.Data.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Datin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Datacontext datacontext;
        private readonly IAuthRepository authRepository;

        public HomeController(Datacontext datacontext,IAuthRepository authRepository)
        {
            this.datacontext = datacontext;
            this.authRepository = authRepository;
        }
        [HttpGet]
       
        public IActionResult Index()
         {
            return Ok(datacontext.tblValues.ToList());

        }

        public async Task<IActionResult> Register(string username,string Password)
        {

            if (await authRepository.UserExist(username))
            {
                return BadRequest("the user already is exist");
            }

            else
            {

                var usercreated =await authRepository.Register(new Models.Users() { UserName = username }, Password);
                return Ok(usercreated);
            }
        }
    }
}
