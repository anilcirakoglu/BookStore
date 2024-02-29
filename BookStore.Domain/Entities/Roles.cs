using BookStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Roles:BaseEntity
    {
       
        public string role { get; set; }
        public string roleInfo { get; set; }

    }
}
