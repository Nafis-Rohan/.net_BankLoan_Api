using DAL.EF.Tables;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repos
{
    internal class BankAccountRepo : IRepo<BankAccount, int, bool>
    {
        UMSContext db;

        public BankAccountRepo()
        {

            db = new UMSContext();
        }


        public bool Create(BankAccount b)
        {
            db.BankAccounts.Add(b);
            return db.SaveChanges() > 0;
        }

        public List<BankAccount> Get()
        {
            return db.BankAccounts.ToList();
        }

        public BankAccount Get(int id)
        {
            return db.BankAccounts.Find(id);
        }

        public bool Update(BankAccount b)
        {
            var exobj = Get(b.Id);
            db.Entry(exobj).CurrentValues.SetValues(b);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
