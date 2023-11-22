using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        List<Group> Search(string searchText);
        List<Group> Sort();
    }
}
