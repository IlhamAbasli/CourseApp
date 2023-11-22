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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> Search(string searchText)
        {
            return AppDbContext<Student>.Datas.Where(x => x.FullName.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToList();
        }

        public List<Student> Sort()
        {
            return AppDbContext<Student>.Datas.OrderBy(x => x.Age).ToList();
        }
    }
}
