using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentModels
{
    public class Fluent_Book
    {
        public int Book_Id { get; set; }
        public string Title { get; set; }

        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public string PriceRange { get; set; }  

        // navigation property - the real relation
        // one to one
        public Fluent_BookDetail BookDetail { get; set; }

        public int Publisher_Id { get; set; }
        public Fluent_Publisher Publisher { get; set; }

        // many to many

        //public List<Fluent_Author> Authors { get; set; }

        // one to many
        public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
