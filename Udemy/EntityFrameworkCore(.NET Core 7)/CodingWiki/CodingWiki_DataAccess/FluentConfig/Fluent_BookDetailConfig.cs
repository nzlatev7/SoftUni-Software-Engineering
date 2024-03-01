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
    public class Fluent_BookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            // name of table
            modelBuilder.ToTable("Fluent_BookDetails");

            // name of columns
            modelBuilder.Property(d => d.NumberOfPages).HasColumnName("Pages");

            // primary key
            modelBuilder.HasKey(b => b.BookDetail_Id);

            // other validations
            modelBuilder.Property(d => d.NumberOfPages).IsRequired();

            // relations
            modelBuilder.HasOne(b => b.Book).WithOne(b => b.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(b => b.Book_Id);
        }
    }
}
