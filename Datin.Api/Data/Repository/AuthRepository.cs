using Datin.Api.Data.Contract;
using Datin.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datin.Api.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Datacontext datacontext;

        public AuthRepository(Datacontext datacontext)
        {
            this.datacontext = datacontext;
        }
        public  Task<Users> Login(string username, string password)
        {
           
            throw new NotImplementedException();
        }

       

        public async Task<Users> Register(Users user, string Password)
        {
            byte[] PasswordHash, PasswordSalt;
            createPasswordHash(Password, out PasswordHash, out PasswordSalt);
            user.Password = Password;
            user.PasswordHash = Password; 
            user.PasswordSalt = Password;
            await datacontext.AddAsync(user);
            await datacontext.SaveChangesAsync();
            return user;
        }

        public void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            throw new NotImplementedException();
        }

        public Task<bool> UserExist(string username)
        {
            throw new NotImplementedException();
        }
    }
}
