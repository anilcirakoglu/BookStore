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
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.Property(f => f.name).IsRequired().HasMaxLength(128);
            builder.Property(f => f.surname).IsRequired().HasMaxLength(128);
            builder.Property(f => f.phonenumber).IsRequired().HasMaxLength(256);
            builder.Property(f => f.email).IsRequired().HasMaxLength(256);
            builder.Property(f=>f.password).IsRequired().HasMaxLength(256);
            builder.Property(f=>f.username).IsRequired().HasMaxLength(256);
           
        }
    }
}
