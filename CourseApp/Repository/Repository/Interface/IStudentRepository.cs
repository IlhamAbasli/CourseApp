using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        List<Student> Search(string searchText);
        List<Student> Sort();
        void Edit(int id, Student group);
    }
}
