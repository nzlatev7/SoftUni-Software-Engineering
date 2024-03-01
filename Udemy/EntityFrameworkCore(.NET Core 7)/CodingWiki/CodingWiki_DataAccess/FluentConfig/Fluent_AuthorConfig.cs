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
    public class Fluent_AuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {

            modelBuilder.HasKey(b => b.Author_Id);
            modelBuilder.Property(a => a.FirstName).HasMaxLength(50)
                    .IsRequired();

            modelBuilder.Property(a => a.LastName).IsRequired();
            modelBuilder.Ignore(a => a.FullName);   
        }
    }
}
