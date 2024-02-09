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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            

            
            builder.Property(f => f.name).IsRequired().HasMaxLength(256);

            builder.Property(f => f.isbn).IsRequired().HasMaxLength(128);

            builder.Property(f => f.category).IsRequired().HasMaxLength(256);

            builder.Property(f => f.published).IsRequired();

            builder.Property(f=>f.author).IsRequired().HasMaxLength(256);

         

            


        }
    }
}
