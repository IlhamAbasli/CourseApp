using Domain.Models;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        void Register(User user);
        bool Login(string email, string password);   

    }
}
