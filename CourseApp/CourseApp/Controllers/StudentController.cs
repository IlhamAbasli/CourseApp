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
    }
}
