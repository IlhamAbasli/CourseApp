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
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> Search(string searchText)
        {
            return AppDbContext<Group>.Datas.Where(x=>x.Name.ToLower().Trim() == searchText.ToLower().Trim()).ToList();
        }

        public List<Group> Sort()
        {
            return AppDbContext<Group>.Datas.OrderBy(x => x.Capacity).ToList();
        }
    }
}
