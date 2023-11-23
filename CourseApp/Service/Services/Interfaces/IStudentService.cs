using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Add(Student student);
        Student Edit(int id);
        bool Delete(int id);
        List<Student> GetAll();
        Student GetById(int id);
        List<Student> Search(string searchText);
        List<Student> Sort();


    }
}
