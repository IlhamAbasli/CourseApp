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
        public void Create(Student student)
        {
            _studentRepository.Create(student);
        }

        public bool Delete(int id)
        {
            return _studentRepository.Delete(id);
        }

        public void Edit(int id, Student student)
        {
            var res = _studentRepository.Edit(id);
            if(res != null)
            {
                if(!string.IsNullOrWhiteSpace(student.FullName))
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
                if(student.Age != 0)
                {
                    res.Age = student.Age;
                }
                if(!string.IsNullOrWhiteSpace(student.Group.Name))
                {
                    res.Group.Name = student.Group.Name;
                }
            }
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
