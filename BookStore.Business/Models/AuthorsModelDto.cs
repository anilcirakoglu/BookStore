using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class AuthorsModelDto
    {
        public DateTime birthday { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
