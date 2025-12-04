using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TKey { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // nullable => null means “not deleted yet”
        public DateTime? ExpireAt { get; set; }

        public string UserName { get; set; }
    }
}
