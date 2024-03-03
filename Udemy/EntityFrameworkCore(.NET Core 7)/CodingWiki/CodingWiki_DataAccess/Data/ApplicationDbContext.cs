using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using CodingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        // q: why we use/need this

        // by default
        //public ApplicationDbContext()
        //{
        //}
        // for the Program.cs config in the Web app
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }


        // rename to Fluent_BookDetails
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }

        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }



        // testing purposes
        //public DbSet<Role> Roles { get; set; }

        // appsettings.json or this method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // adding logging to see your query!
            // hardcoded ways
            //optionsBuilder.UseSqlServer("Server=.;Database=CodingWiki;Trusted_Connection=True;TrustServerCertificate=true;")
            //    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new{ u.Author_Id, u.Book_Id });

            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookDetail)
                .WithOne(b => b.Book)
                .HasForeignKey<BookDetail>(e => e.BookDetail_Id);

            modelBuilder.ApplyConfiguration(new Fluent_AuthorConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookDetailConfig());
            modelBuilder.ApplyConfiguration(new Fluent_PublisherConfig());

            modelBuilder.Entity<Book>().HasData(
                new Book() { Book_Id = 2, Title = "spider", ISBN = "123B12", Price = 10.99m, Publisher_Id = 2 },
                new Book() { Book_Id = 4, Title = "panda", ISBN = "2323", Price = 10.99m, Publisher_Id = 1 },
                new Book() { Book_Id = 5, Title = "wow", ISBN = "23", Price = 16.99m, Publisher_Id = 1 }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role() { Role_Id = 1, Name = "Normal" },
                new Role() { Role_Id = 2, Name = "Admin" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher() { Publisher_Id = 1, Name = "Stoqn", Location = "efeoeffe" },
                new Publisher() { Publisher_Id = 2, Name = "Mariqn", Location = "wdwwd"},
                new Publisher() { Publisher_Id = 4, Name = "Andrei", Location = "vitoshka" }
            );
        }
    }
}
