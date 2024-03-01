using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Role
    {
        [Key]
        public int Role_Id { get; set; }
        public string Name { get; set; }
    }
}
