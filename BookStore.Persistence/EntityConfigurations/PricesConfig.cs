using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.EntityConfigurations
{
    public class PricesConfig: IEntityTypeConfiguration<Prices>
    {
       
        

        public void Configure(EntityTypeBuilder<Prices> builder)
        {
            builder.ToTable("Prices");
            builder.Property(f => f.bookId).IsRequired().HasMaxLength(256);
            builder.Property(f => f.price).IsRequired().HasMaxLength(256);
        }
    }
}
