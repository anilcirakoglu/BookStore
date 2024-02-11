using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string isbn { get; set; }
        public string category { get; set; }
        public bool published { get; set; }
        public string author { get; set; }
    }
}
