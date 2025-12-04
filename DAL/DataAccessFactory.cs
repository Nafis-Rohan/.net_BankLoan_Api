using DAL.Interfaces;
using DAL.Repos;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class DataAccessFactory
    {
        public static IRepo<Customer,int,bool> CustomerData()
        {
            return new CustomerRepo();
        }

        public static IRepo<BankAccount, int, bool> BankAccountData() { 

            return new BankAccountRepo(); 
        }


        public static IRepo<LoanApplication, int, bool> LoanApplicationData() { 
            
            
            return new LoanApplicationRepo(); 
        
        }

        public static IRepo<Token , string, Token> TokenData()
        {
            return new TokenRepo();
        }


        public static IInterestRateCount<float> InterestData()
        {
            return new LoanApplicationRepo();
        }

        public static IEMICal<float> EmiData() {

            return new LoanApplicationRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new CustomerRepo();
        }

        


    }
}
