using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.EntityConfigurations
{
    public class CustomerRoleConfig : IEntityTypeConfiguration<CustomerRole>
    {
        public void Configure(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.ToTable("CustomerRoleMapping");
            builder.HasKey(x => x.id);
            builder.Property(f => f.Customer_id).IsRequired().HasMaxLength(256);
            builder.Property(f => f.Role_id).IsRequired().HasMaxLength(256);
           
        }
    }
}
