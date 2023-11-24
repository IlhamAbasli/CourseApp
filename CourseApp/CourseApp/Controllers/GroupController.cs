using Domain.Models;
using Service.Exceptions;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    internal class GroupController
    {
        private readonly IGroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Enter group name");
            Name: string groupName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupName))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Group name is required!");
                goto Name;
            }

            var res = _groupService.GetAll();
            foreach (var item in res)
            {
                if (item.Name == groupName)
                {
                    Console.WriteLine("Group name has already exist");
                    goto Name;
                }
            }


            Console.WriteLine("Enter group capacity");
            Capacity: string capacityStr = Console.ReadLine();
            try
            {
                if (string.IsNullOrWhiteSpace(capacityStr))
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Capacity is required!");
                    goto Capacity;
                }
                bool IsCorrectFormat = int.TryParse(capacityStr, out int capacity);
                if (!IsCorrectFormat)
                {
                    throw new WrongFormatException("Capacity format is wrong, enter correct format");
                }

                _groupService.Create(new Group { Name = groupName, Capacity = capacity });
            }
            catch (WrongFormatException ex)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine($"{ex.Message}");
                goto Capacity;
            }
        }

        public void GetAll()
        {
            try
            {
                var res = _groupService.GetAll();
                if (res.Count == 0)
                { 
                    throw new DataNotFoundException(ExceptionMessages.EmptyListMessage);
                }
                Console.Clear();
                int row = 0;
                foreach (var group in res)
                {
                    row++;
                    Console.WriteLine($"\n**{row}.\n**Group name: {group.Name}\n**Group capacity: {group.Capacity}");
                }
            }
            catch (DataNotFoundException ex)
            {
                Console.Clear();
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
            }
        }


        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Enter the group ID you want to delete: ");
            ID: string groupID = Console.ReadLine();
            bool IsCorrectFormat = int.TryParse(groupID, out int id);
            try
            {
                if (!IsCorrectFormat)
                {
                    throw new WrongFormatException(ExceptionMessages.WrongIdFormatMessage);
                }
                if (!_groupService.Delete(id))
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Group not found with this ID");
                }
                else
                {
                    ConsoleColor.Green.ConsoleWriteLine("Group successfully deleted");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
                goto ID;
            }
        }

        public void Search()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter group name: ");
                string groupName = Console.ReadLine();
                
                var res = _groupService.Search(groupName);

                if (res.Count == 0)
                {
                    throw new DataNotFoundException("Group not found");
                }

                foreach (var group in res)
                {
                    Console.WriteLine($"\n**Group name: {group.Name}\n**Group capacity: {group.Capacity}");
                }
            }
            catch (DataNotFoundException ex)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
            }
        }

        public void GetById()
        {
            Console.Clear();
            Console.WriteLine("Enter group ID:");

            ID: bool IsCorrectFormat = int.TryParse(Console.ReadLine(), out int id);
            try
            {
                if (!IsCorrectFormat)
                {
                    throw new WrongFormatException(ExceptionMessages.WrongIdFormatMessage);
                }
                var group = _groupService.GetById(id);
                if (group == null)
                {
                    throw new DataNotFoundException(ExceptionMessages.GroupNotFoundWithId);
                }
                Console.WriteLine($"\n**Group name: {group.Name}\n**Group capacity: {group.Capacity}");
            }
            catch (Exception ex)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
                goto ID;
            }
        }

        public void Sort()
        {
            try
            {
                var res = _groupService.Sort();
                if (res.Count == 0)
                {
                    throw new DataNotFoundException(ExceptionMessages.EmptyListMessage);
                }
                Console.Clear();
                foreach (var group in res)
                {
                    Console.WriteLine($"\n**Group name: {group.Name}\n**Group capacity: {group.Capacity}");
                }
            }
            catch (DataNotFoundException ex)
            {
                Console.Clear();
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
            }

        }

        public void Edit()
        {
            Console.Clear();
            Console.WriteLine("Enter group ID of the group you want to edit: ");
            Id: string groupID = Console.ReadLine();
            try
            {
                bool IsCorrectFormat = int.TryParse(groupID, out int id);
                if (IsCorrectFormat)
                {
                    var res = _groupService.GetById(id);
                    if (res == null)
                    {
                        throw new DataNotFoundException(ExceptionMessages.GroupNotFoundWithId);
                    }
                    if (res is not null)
                    {
                        Console.WriteLine($"\n**Group name: {res.Name}\n**Group capacity: {res.Capacity}");

                        Console.WriteLine("Enter group name for change:");
                        Name: string name = Console.ReadLine();
                        var groups = _groupService.GetAll();
                        foreach (var group in groups)
                        {
                            if (group.Name == name)
                            {
                                Console.WriteLine("Group name has already exist");
                                goto Name;
                            }
                        }

                        Console.WriteLine("Enter group capacity for change:");
                        string? capacityStr = Console.ReadLine();
                        bool isCorrect = int.TryParse(capacityStr, out int capacity);

                        _groupService.Edit(id, new Group { Name = name, Capacity = capacity });
                        ConsoleColor.Green.ConsoleWriteLine("Group successfully edited");
                    }
                }
                if (!IsCorrectFormat)
                {
                    throw new WrongFormatException(ExceptionMessages.WrongIdFormatMessage);
                }
            }
            catch(WrongFormatException ex)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
                goto Id;
            }
            catch(DataNotFoundException ex)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine(ex.Message);
                goto Id;
            }
        }
    }
}
