
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IAccountRepository
    {
        void Register(User user);
        bool Login(string email, string password);
    }
}
