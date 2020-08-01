using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datin.Api.Data.entities
{
    public class Values
    {
        public Values()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string  Name { get; set; }
    }
}
