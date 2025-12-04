using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class AccTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
    }
}
