using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datin.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Datin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Datacontext datacontext;

        public HomeController(Datacontext datacontext)
        {
            this.datacontext = datacontext;
        }
        [HttpGet]
       
        public IActionResult Index()
         {
            return Ok(datacontext.tblValues.ToList());

        }
    }
}
