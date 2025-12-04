using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }



        [ForeignKey("Ac")]
        public int AccTypeId { get; set; }
        public virtual AccTypes Ac {  get; set; }




        [Column(TypeName = "FLOAT")]
        public float Balance { get; set; }




        [ForeignKey("Cus")]
        public int CustomerId {  get; set; }
        public virtual Customer Cus { get; set; }
    }
}
