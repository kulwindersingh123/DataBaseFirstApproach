using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment22.Models
{
    public class Employee
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Phone", TypeName = "varchar(30)")]
        public string Phone { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        [Column("IsActive")]
        public string IsActive { get; set; }

    }
            
}
