using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerDTO
    {
  
        public int Id { get; set; }
     
        public string Name { get; set; }

      
        public float Income { get; set; }

        public int CreditScore { get; set; }

        public string UserName { get; set; }

        
        public int EId { get; set; }
    }
}
