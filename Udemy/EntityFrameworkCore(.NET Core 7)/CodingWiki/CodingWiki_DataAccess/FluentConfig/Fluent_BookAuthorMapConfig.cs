using CodingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class Fluent_BookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(b => new { b.Book_Id, b.Author_Id });
            modelBuilder.HasOne(b => b.Author).WithMany(a => a.BookAuthorMap).HasForeignKey(b => b.Author_Id);
            modelBuilder.HasOne(b => b.Book).WithMany(a => a.BookAuthorMap).HasForeignKey(b => b.Book_Id);
        }   
    }
}
