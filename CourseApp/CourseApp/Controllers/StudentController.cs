using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        public void Add()
        {
            Console.WriteLine("*Enter required datas of student*");
            Console.WriteLine("\nEnter student fullname: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter student address: ");
            string address = Console.ReadLine();

            Console.WriteLine("Enter student Age: ");
            string ageStr = Console.ReadLine();

            Console.WriteLine("Enter student phone number");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter student Group");

        }

        public void Delete()
        {
            Console.WriteLine("Enter the student ID you want to delete: ");
            ID: string studentID = Console.ReadLine();
            bool IsCorrectFormat = int.TryParse(studentID, out int id);

            if (!IsCorrectFormat)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("ID format is wrong,try again");
                goto ID;
            }
            if (!_studentService.Delete(id))
            {
                ConsoleColor.Red.ConsoleWriteLine("Student not found with this ID");
            }
            else
            {
                ConsoleColor.Green.ConsoleWriteLine("Student successfully deleted");
            }
        }

        public void GetAll()
        {
            var res = _studentService.GetAll();

            foreach (var student in res)
            {
                Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
            }
        }

        public void GetById()
        {
            Console.WriteLine("Enter student ID:");

            ID: bool IsCorrectFormat = int.TryParse(Console.ReadLine(), out int id);
            if (!IsCorrectFormat)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("ID format is wrong,try again");
                goto ID;
            }
            var student = _studentService.GetById(id);

            if (student == null)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Student not found with this ID");
                goto ID;
            }

            Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
        }

        public void Search()
        {
            Console.WriteLine("Enter group name:");
            string studentName = Console.ReadLine();

            var res = _studentService.Search(studentName);

            if (res.Count == 0)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Student not found");
                return;
            }

            foreach (var student in res)
            {
                Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
            }
        }

        public void Sort()
        {
            var res = _studentService.Sort();

            foreach (var student in res)
            {
                Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
            }
        }
    }
}
