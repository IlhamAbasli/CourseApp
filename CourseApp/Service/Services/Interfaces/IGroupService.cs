using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group group);
        void Edit(Group group);
        void Delete(Group group);
        List<Group> GetAll();
        Group GetById(int id);  
        List<Group> Search(string searchText);
        List<Group> Sort();
    }
}
