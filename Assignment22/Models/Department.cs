using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Assignment22.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Column("Name",TypeName ="varchar(30)")]
        public string Name { get; set; }
        [Column("IsActive")]
        public string IsActive { get; set; }

    }
}
