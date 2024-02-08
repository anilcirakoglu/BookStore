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
            builder.ToTable("USERS");
            builder.Property(f => f.Name).IsRequired().HasMaxLength(128);
            builder.Property(f => f.surname).IsRequired().HasMaxLength(128);
            builder.Property(f => f.phoneNumber).IsRequired().HasMaxLength(256);
            builder.Property(f => f.email).IsRequired().HasMaxLength(256);
        }
    }
}
