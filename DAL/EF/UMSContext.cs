using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    internal class UMSContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts{ get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<Employments> Employments { get; set; }
        public DbSet<LoanTypes> LoanTypes { get; set; }
        public DbSet<AccTypes> AccTypes { get; set; }
        public DbSet<Token> Tokens { get; set; }


    }
}
