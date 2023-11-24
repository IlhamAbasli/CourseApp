﻿using Domain.Models;
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
            Student student = new Student();
            var res = _groupService.GetById(groupId);
            if(res == null)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Group not found");
                goto GroupId;
            }else if(_studentService.GetAll().Count >= res.Capacity)
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

            Console.WriteLine("Enter student address: ");
            Address: string address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Address is required!");
                goto Address;
            }

            Console.WriteLine("Enter student Age: ");
            Age: string ageStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Age is required!");
                goto Age;
            }
            bool IsCorrectType = byte.TryParse(ageStr, out byte age);
            if (!IsCorrectType)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Age format is wrong please enter correct format: ");
                goto Age;
            }

            Console.WriteLine("Enter student phone number");
            Phone: string phoneNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Phone number is required!");
                goto Phone;
            }
            else if (Regex.IsMatch(phoneNumber, "[a-zA-Z]"))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Invalid phone number format");
                goto Phone;
            }

            _studentService.Create(new Student { FullName = fullName, Phone = phoneNumber, Address = address, Age = age, Group = res });
            ConsoleColor.Green.ConsoleWriteLine("Student successfully created");





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
            Console.Clear();
            foreach (var student in res)
            {
                Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
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

            Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
        }

        public void Search()
        {
            Console.Clear();
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
            Console.Clear();
            foreach (var student in res)
            {
                Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");
            }
        }

        public void Edit()
        {
            Console.Clear();
            Console.WriteLine("Enter student ID of the group you want to edit: ");
            Id: string studentID = Console.ReadLine();

            bool IsCorrectFormat = int.TryParse(studentID, out int id);
            if (IsCorrectFormat)
            {
                var student = _studentService.GetById(id);
                if (student == null)
                {
                    Console.WriteLine("Student not found with this ID,try again");
                    goto Id;
                }
                if (student is not null)
                {
                    Console.WriteLine($"**Student Fullname: {student.FullName}\n**Student address: {student.Address}\n**Student age: {student.Age}\n**Student phone number: {student.Phone}\n**Student group: {student.Group.Name}");

                    Console.WriteLine("Enter student full name for change:");
                    string fullName = Console.ReadLine();

                    Console.WriteLine("Enter student address for change:");
                    string address = Console.ReadLine();

                    Console.WriteLine("Enter student age for change:");
                    string ageStr = Console.ReadLine();
                    bool isCorrect = byte.TryParse(ageStr, out byte age);

                    Console.WriteLine("Enter student phone number for change:");
                    Phone: string phoneNumber = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        ConsoleColor.DarkRed.ConsoleWriteLine("Phone number is required!");
                    }
                    else if (Regex.IsMatch(phoneNumber, "[a-zA-Z]"))
                    {
                        ConsoleColor.DarkRed.ConsoleWriteLine("Invalid phone number format");
                        goto Phone;
                    }

                    Console.WriteLine("Enter group name for change");
                    string groupName = Console.ReadLine();
                    




                    _studentService.Edit(id,new Student { FullName = fullName, Address = address, Age = age, Phone = phoneNumber);
                    ConsoleColor.Green.ConsoleWriteLine("Group successfully edited");
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
