using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LoanApplicationRepo : IRepo<LoanApplication, int, bool> , IInterestRateCount<float> , IEMICal<float>
    {
        UMSContext db;
        public LoanApplicationRepo() { 
            db = new UMSContext();
        }

        public bool Create(LoanApplication l) { 
            
            db.LoanApplications.Add(l);
            return db.SaveChanges() > 0;
        }

        public List<LoanApplication> Get() {

            return  db.LoanApplications.ToList();
        }

        public LoanApplication Get(int id)
        {
            return db.LoanApplications.Find(id);

        }

        public bool Update(LoanApplication l)
        {
            var exobj = Get(l.Id);
            db.Entry(exobj).CurrentValues.SetValues(l);
            return db.SaveChanges()>0;
            
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            db.LoanApplications.Remove(data);
            return db.SaveChanges() > 0;

        }

        public float CalculateInterest(int id)
        {
            var loan = DataAccessFactory.LoanApplicationData().Get(id);

            if (loan == null)
            {
                throw new Exception("Loan not found");
            }

            float principal = loan.PrincipalAmmount;
            float rate = loan.InterestRate; 

            
            double years = (loan.DueDate - loan.StartDate).TotalDays / 365.0;

            
            float interest = (float)((principal * rate * years) / 100);

            return interest;
        }

        public float CalculateEmi(int id)
        {
            var loan = DataAccessFactory.LoanApplicationData().Get(id);


            if (loan == null)
            {
                throw new Exception("Loan not found");
            }
            
            int n = (int)((loan.DueDate - loan.StartDate).TotalDays / 30);
            float principal = loan.PrincipalAmmount;
            float rate = loan.InterestRate / 100 / 12; 

            float emi = (principal * rate * (float)Math.Pow(1 + rate, n)) /
                   (float)(Math.Pow(1 + rate, n) - 1);

            return emi;
        }
    }
}
