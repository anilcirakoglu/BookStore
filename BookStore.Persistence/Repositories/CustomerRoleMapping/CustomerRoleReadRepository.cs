
using BookStore.Application.Repositories;
using BookStore.Persistence.Context;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class CustomerRoleReadRepository : ReadRepository<CustomerRole>, ICustomerRoleReadRepository
    {
        public CustomerRoleReadRepository(AppDbContext context):base(context) 
        {
        }
    }
}
