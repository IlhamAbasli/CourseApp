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
        public void Edit(int id, Student student)
        {
            var res = GetById(id);
            if (res != null)
            {
                if (!string.IsNullOrWhiteSpace(student.FullName))
                {
                    res.FullName = student.FullName;
                }
                if (!string.IsNullOrWhiteSpace(student.Address))
                {
                    res.Address = student.Address;
                }
                if (!string.IsNullOrWhiteSpace(student.Phone))
                {
                    res.Phone = student.Phone;
                }
                if (student.Age is not 0)
                {
                    res.Age = student.Age;
                }
                if (student.Group is not null)
                {
                    res.Group = student.Group;
                }
            }
        }

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
