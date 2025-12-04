using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }


        [Column(TypeName = "FLOAT")]
        public float Income { get; set; }




        //[Required]
        //[StringLength(50)]
        //[Column(TypeName = "VARCHAR")]
        //public string EmployeementType { get; set; }

        [ForeignKey("Emps")]
        public int EId { get; set; }
        

        public int CreditScore { get; set; }


        public virtual Employments Emps { get; set; }
    }
}
