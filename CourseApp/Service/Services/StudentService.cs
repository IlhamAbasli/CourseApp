using Domain.Models;
using Repository.Repository;
using Repository.Repository.Interface;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public void Add(Student student)
        {
            _studentRepository.Create(student);
        }

        public bool Delete(int id)
        {
            return _studentRepository.Delete(id);
        }

        public Student Edit(int id)
        {
            return _studentRepository.Edit(id);
        } 

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> Search(string searchText)
        {
            return _studentRepository.Search(searchText);
        }

        public List<Student> Sort()
        {
            return _studentRepository.Sort();
        }
    }
}
