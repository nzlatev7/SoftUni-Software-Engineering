using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentModels
{
    public class Fluent_Publisher
    {
        public int Publisher_Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        // testing purposes
        // navigation prop

        //[ForeignKey("Role")]
        //[AllowNull] - can not have nullable (int can not be null)
        //public int Role_Id { get; set; }

        ///[Required] 
        //[AllowNull]
        //public Role Role { get; set; }

        //// navigation prop to retrieve all books for publisher
        ///// one to many
        public virtual List<Fluent_Book> Books { get; set; }
    }
}
