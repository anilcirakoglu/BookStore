using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.EntityConfigurations
{
    public class AuthorsConfig : IEntityTypeConfiguration<Authors>
    {
        public void Configure(EntityTypeBuilder<Authors> builder)
        {
            builder.ToTable("Authors");



            builder.Property(f => f.tc).IsRequired().HasMaxLength(256);

            builder.Property(f => f.birthday).IsRequired().HasMaxLength(128);

            builder.Property(f => f.name).IsRequired().HasMaxLength(256);

            builder.Property(f => f.email).IsRequired().HasMaxLength(256); ;

            builder.Property(f => f.gender).IsRequired().HasMaxLength(256);






        }

       
    }
}
