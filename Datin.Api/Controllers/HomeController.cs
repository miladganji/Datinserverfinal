using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Datin.Api.Data;
using Datin.Api.Data.Contract;
using Datin.Api.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Datin.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Datacontext datacontext;
        private readonly IAuthRepository authRepository;
        private readonly IConfiguration configuration;

        public HomeController(Datacontext datacontext,IAuthRepository authRepository,IConfiguration configuration)
        {
            this.datacontext = datacontext;
            this.authRepository = authRepository;
            this.configuration = configuration;
        }
        [HttpGet]
       
        public IActionResult Index()
         {
            return Ok(datacontext.tblValues.ToList());

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]userCreatedDto input)
        {

            if (await authRepository.UserExist(input.UserName))
            {
                return BadRequest("the user already is exist");
            }

            else
            {

                var usercreated =await authRepository.Register(new Models.Users() { UserName = input.UserName }, input.Password);
                return Ok(usercreated);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLoginDto)
        {
            var userFormRepo = await authRepository.Login(userLoginDto.UserName, userLoginDto.Password);
            if (userFormRepo == null)
            {
                return Unauthorized();
            }

            else {

                var Claims =new[]
                {


                    new Claim(ClaimTypes.NameIdentifier,userFormRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name,userFormRepo.UserName.ToString())
               };

                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
                var Scred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
                var TokenDescriptor =new SecurityTokenDescriptor{
                
                    Subject=new ClaimsIdentity(Claims),
                    Expires=DateTime.Now.AddDays(1),
                    SigningCredentials=Scred,


                };
                var TokenHandler = new JwtSecurityTokenHandler();
                var Token = TokenHandler.CreateToken(TokenDescriptor);
                var FinalToken = TokenHandler.WriteToken(Token);
                return Ok(new { 
                Token=FinalToken
                });
            }
        }

    }
}
