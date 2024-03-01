using CodingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class Fluent_BookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Book_Id);
            modelBuilder.Property(a => a.ISBN).HasMaxLength(20).IsRequired();
            modelBuilder.Property(a => a.Title).IsRequired();
            modelBuilder.Ignore(a => a.PriceRange);
            modelBuilder.HasOne(b => b.Publisher).WithMany(p => p.Books)
                    .HasForeignKey(b => b.Publisher_Id);
        }
    }
}
