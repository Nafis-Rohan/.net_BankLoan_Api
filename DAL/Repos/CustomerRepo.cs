using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CustomerRepo : IRepo<Customer,int,bool> , IAuth<bool>
    {
        UMSContext db;

        public CustomerRepo() { 
            
            db = new UMSContext();
        }

        public bool Authenticate(string userName, string password) {
            var data = db.Customers.FirstOrDefault(u=>u.UserName.Equals(userName) && u.Password.Equals(password));
            return data != null;
        }


        public bool Create(Customer c)
        {
            db.Customers.Add(c);
            return db.SaveChanges() > 0;
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public bool Update(Customer c)
        {
            var exCus = Get(c.Id);
            db.Entry(exCus).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            db.Customers.Remove(data);
            return db.SaveChanges() > 0;
        }
        


        
    }
}
