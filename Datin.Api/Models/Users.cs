using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datin.Api.Models
{
    public class Users
    {
       
        public Users()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string  UserName { get; set; }
        public string  Password { get; set; }
        public string  PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
