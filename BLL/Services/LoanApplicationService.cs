using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoanApplicationService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LoanApplication, LoanApplicationDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static bool Create(LoanApplicationDTO c )
        {

            var customer = DataAccessFactory.CustomerData().Get(c.CustomerId);

            var accounts = (from a in DataAccessFactory.BankAccountData().Get()
                            where a.CustomerId == c.CustomerId
                            select a).ToList();

            if (accounts.Count == 0) {
                return false;
            }
                

            if (customer == null)
            {
                return false;
            }

            c.StatusId = 1; // Pending
            c.StartDate = DateTime.Now; 


                    

            switch (c.LoanTypeId)
            {
                case 1: // Personal 
                    c.DueDate = c.StartDate.AddYears(3); 
                    break;

                case 2: // Car 
                    c.DueDate = c.StartDate.AddYears(5); 
                    break;

                case 3: // Education 
                    c.DueDate = c.StartDate.AddYears(7); 
                    break;

                case 4: // Business 
                    c.DueDate = c.StartDate.AddYears(10); 
                    break;

                default:
                    throw new Exception("Invalid Loan Type");
            }

            var data = GetMapper().Map<LoanApplication>(c);
            return DataAccessFactory.LoanApplicationData().Create(data);



        }

        public static List<LoanApplicationDTO> Get()
        {
            var data = DataAccessFactory.LoanApplicationData().Get();
            return GetMapper().Map<List<LoanApplicationDTO>>(data);
        }

        public static LoanApplicationDTO Get(int id)
        {
            var data = DataAccessFactory.LoanApplicationData().Get(id);
            return GetMapper().Map<LoanApplicationDTO> (data);
        }
        public static bool Update(LoanApplicationDTO c)
        {
            var data = GetMapper().Map<LoanApplication>(c);
            return DataAccessFactory.LoanApplicationData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.LoanApplicationData().Delete(id);
        }


        public static float CalculateInterest(int id)
        {
            return DataAccessFactory.InterestData().CalculateInterest(id);
        }


        public static float EmiCal(int id) {

            return DataAccessFactory.EmiData().CalculateEmi(id);
        }

        public static bool ApproveLoan(int id)
        {
            var loan = DataAccessFactory.LoanApplicationData().Get(id);
            if (loan == null) throw new Exception("Loan not found");



            if (loan.StatusId != 2) { loan.StatusId = 2; }

            
            var account = (from a in DataAccessFactory.BankAccountData().Get()
                           where a.CustomerId == loan.CustomerId
                           select a).FirstOrDefault();

            if (account == null)
            {
                throw new Exception("Customer doesnt have a bank account");

            }
            account.Balance += loan.PrincipalAmmount;

            
            DataAccessFactory.BankAccountData().Update(account);
            return DataAccessFactory.LoanApplicationData().Update(loan);
        }


    }   
}
