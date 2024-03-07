using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentModels
{
    public class Fluent_Author
    {
        public int Author_Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Location { get; set; }

        public string FullName { get => FirstName + " " + LastName; }

        //many to many

        //public List<Fluent_Book> Books { get; set; }

        // one to many
        public virtual List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
