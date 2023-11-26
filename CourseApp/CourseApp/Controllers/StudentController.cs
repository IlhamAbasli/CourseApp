using Domain.Models;
using Service.Exceptions;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public StudentController()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();

        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("*Enter required datas of student*");
            Console.WriteLine("\nWhich group do you want to add this student?");
            GroupId: string groupIdStr = Console.ReadLine();
            bool IsCorrectFormat = int.TryParse(groupIdStr, out int groupId);
            try
            {
                Student student = new Student();
                var groups = _groupService.GetAll();
                if (groups.Count == 0)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("There is no group in system, create a group first");
                    return;
                }
                var res = _groupService.GetById(groupId);
                if (res == null)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Group not found");
                    goto GroupId;
                }
                else if (_studentService.GetAll().Count >= res.Capacity)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("This group is full please add to different group");
                    goto GroupId;
                }
                else
                {
                    student.Group = res;
                    ConsoleColor.Green.ConsoleWriteLine($"The student will be added to the {res.Name}");
                }




                Console.WriteLine("\nEnter student fullname: ");
                Name: string fullName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Fullname is required!");
                    goto Name;
                }
                if (!NameExtension.CheckFullName(fullName))
                {
                    goto Name;
                }

                Console.WriteLine("Enter student address: ");
                Address: string address = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(address))
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Address is required!");
                    goto Address;
                }
                Console.WriteLine("Enter student age: ");
                Age: string ageStr = Console.ReadLine();
                bool IsCorrectType = byte.TryParse(ageStr, out byte age);
                try
                {
                    if (!IsCorrectType)
                    {
                        throw new WrongFormatException(ExceptionMessages.WrongAgeFormat);
                    }
                }
                catch (WrongFormatException ex)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
                    goto Age;
                }
                if (string.IsNullOrWhiteSpace(ageStr))
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Age is required!");
                    goto Age;
                }
                if (!NameExtension.CheckAge(ageStr))
                {
                    goto Age;
                }
                if (age > 70 || age < 18)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Age must be between 18-70");
                    goto Age;
                }
                if (age == 0)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Age cant be zero");
                    goto Age;
                }

                Console.WriteLine("Enter student phone number");
                Phone: string phoneNumber = Console.ReadLine();
                try
                {
                    if (string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        ConsoleColor.DarkRed.ConsoleWriteLine("Phone number is required!");
                        goto Phone;
                    }
                    if(Regex.IsMatch(phoneNumber, @"\s"))
                    {
                        throw new WrongFormatException(ExceptionMessages.WrongPhoneNumberFormat);
                    }
                    if (Regex.IsMatch(phoneNumber, "[a-zA-Z]"))
                    {
                        throw new WrongFormatException(ExceptionMessages.WrongPhoneNumberFormat);
                    }
                }
                catch (WrongFormatException ex)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
                    goto Phone;
                }

                _studentService.Create(new Student { FullName = fullName, Phone = phoneNumber, Address = address, Age = age, Group = res });
                ConsoleColor.Green.ConsoleWriteLine("Student successfully created");
            }
            catch (DataNotFoundException ex)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
                goto GroupId;
            }





        }

        public void Delete()
        {
            Console.Clear();
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
            if(res.Count == 0)
            {
                Console.Clear();
                ConsoleColor.DarkRed.ConsoleWriteLine("Student list is empty");
                return;
            }
            Console.Clear();
            int row = 0;
            foreach (var student in res)
            {
                string students = $"\n{++row}.\n**Student fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}";
                ConsoleColor.DarkYellow.ConsoleWriteLine(students);
            }
        }

        public void GetById()
        {
            Console.Clear();
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

            string data = $"\n**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}";
            ConsoleColor.DarkYellow.ConsoleWriteLine(data);
        }

        public void Search()
        {
            Console.Clear();
            Console.WriteLine("Enter student name:");
            string studentName = Console.ReadLine();

            var res = _studentService.Search(studentName);

            if (res.Count == 0)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Student not found");
                return;
            }
            int row = 0;
            foreach (var student in res)
            {
                Console.WriteLine($"{++row}.\n**Student fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
            }
        }

        public void Sort()
        {
            var res = _studentService.Sort();
            Console.Clear();
            int row = 0;
            foreach (var student in res)
            {
                string students = $"\n{++row}.\n**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}";
                ConsoleColor.DarkYellow.ConsoleWriteLine(students);
            }
        }

        public void Edit()
        {
            Console.Clear();
            Console.WriteLine("Enter student ID you want to edit: ");
            Id: string studentID = Console.ReadLine();

            bool IsCorrectFormat = int.TryParse(studentID, out int id);
            if (IsCorrectFormat)
            {
                var student = _studentService.GetById(id);
                if (student == null)
                {
                    Console.WriteLine("Student not found with this ID,try again");
                    
                }
                if (student is not null)
                {
                    string data = $"\n**Student fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}";
                    ConsoleColor.DarkMagenta.ConsoleWriteLine(data);

                    Console.WriteLine("Enter student full name for change:");
                    FullName: string fullName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        if (!NameExtension.CheckFullName(fullName))
                        {
                            goto FullName;
                        }
                    }

                    Console.WriteLine("Enter student address for change:");
                    string address = Console.ReadLine();

                    Console.WriteLine("Enter student age for change:");
                    Age: string ageStr = Console.ReadLine();
                    bool isCorrect = byte.TryParse(ageStr, out byte age);
                    if(!string.IsNullOrWhiteSpace(ageStr))
                    {
                        if (!NameExtension.CheckAge(ageStr))
                        {
                            goto Age;
                        }
                        if (age > 70 && age < 18)
                        {
                            ConsoleColor.DarkRed.ConsoleWriteLine("Age must be between 18 and 70");
                            goto Age;
                        }
                        if (age == 0)
                        {
                            ConsoleColor.DarkRed.ConsoleWriteLine("Age cant be zero");
                            goto Age;
                        }
                    }



                    Console.WriteLine("Enter student phone number for change:");
                    Phone: string phoneNumber = Console.ReadLine();
                    if (Regex.IsMatch(phoneNumber, @"\s"))
                    {
                        ConsoleColor.DarkRed.ConsoleWriteLine("Invalid phone number format");
                        goto Phone;
                    }
                    if (Regex.IsMatch(phoneNumber, "[a-zA-Z]"))
                    {
                        ConsoleColor.DarkRed.ConsoleWriteLine("Invalid phone number format");
                        goto Phone;
                    }

                    Console.WriteLine("Enter group ID for change student group");
                    GroupId: string groupIdStr = Console.ReadLine();
                    bool correctFormat = int.TryParse(groupIdStr, out int groupId);
                    var res = _groupService.GetById(groupId);
                    if (res is not null)
                    {
                        if(_studentService.GetAll().Count >= res.Capacity)
                        {
                            ConsoleColor.DarkRed.ConsoleWriteLine("This group is full please change to different group");
                            goto GroupId;
                        }
                    }
                    _studentService.Edit(id, new Student { FullName = fullName, Address = address, Age = age, Phone = phoneNumber, Group = res });
                    ConsoleColor.Green.ConsoleWriteLine("Stuent successfully edited");
                }
            }
            if (!IsCorrectFormat)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("ID format is wrong,try again");
                goto Id;
            }
        }
    }
}
