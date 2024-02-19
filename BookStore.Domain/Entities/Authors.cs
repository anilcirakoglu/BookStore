using BookStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Authors : BaseEntity
    {
        public int tc {  get; set; }
        public DateTime birthday { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }

    }
}
