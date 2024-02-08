using BookStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Prices : BaseEntity
    {
        ///   public int Id { get; set; }
        public int bookId { get; set; }
        public decimal price { get; set; }

    }
}
