using BookStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class CustomerRole : BaseEntity
    {
        
        public int Customer_id { get; set; }
        public int Role_id { get; set; }
    }
}
