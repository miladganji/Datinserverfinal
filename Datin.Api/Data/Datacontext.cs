using Datin.Api.Data.entities;
using Datin.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datin.Api.Data
{
    public class Datacontext:DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options):base(options)
        {

        }

        public DbSet<Values> tblValues{ get; set; }
        public DbSet<Users>  tblUsers{ get; set; }
    }
}
