using Domain.Models;
using Repository.Datas;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private static int _id = 1;
        public bool Login(string email, string password)
        {
            var datas = AppDbContext<User>.Datas;
            foreach (var data in datas)
            {
                if(data.Email == email && data.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public void Register(User user)
        {
            user.Id = _id++;
            AppDbContext<User>.Datas.Add(user); 
        }
    }
}
