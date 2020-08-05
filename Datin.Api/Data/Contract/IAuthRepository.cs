using Datin.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datin.Api.Data.Contract
{
  public  interface IAuthRepository
    {
        Task<Users> Register(Users user,string Password);
        Task<Users> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
