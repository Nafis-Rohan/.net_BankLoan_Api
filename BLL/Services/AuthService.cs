using AutoMapper;
using DAL;
using DAL.EF.Tables;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string userName ,string password) {


            var res = DataAccessFactory.AuthData().Authenticate(userName, password);
            if (res)
            {
                var token = new Token();
                token.UserName = userName;
                token.CreatedAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Create(token);
                if(ret != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token, TokenDTO>().ReverseMap();
                    });
                    var mapper =  new Mapper(config);
                    return mapper.Map<TokenDTO>(ret);
                }
            }



            return null;
        }

        public static bool IsTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);

            //var customer = DataAccessFactory.CustomerData().Get(id);  && extk.UserName == customer.UserName
            if (extk != null && extk.ExpireAt == null)
            {
                return true;
            }
            return false;
        }

        

        public static bool Logout(int id)
        {
            var customer = DataAccessFactory.CustomerData().Get(id);
            if (customer == null) return false;

            var token = (from a in DataAccessFactory.TokenData().Get()
                         where a.UserName == customer.UserName && a.ExpireAt == null
                         select a).FirstOrDefault();

            if (token == null) return false;

            var tkey = token.TKey;
            var extk = DataAccessFactory.TokenData().Get(tkey);
            extk.ExpireAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null)
            {
                return true;
            }
            return false;
        }
    }
}
