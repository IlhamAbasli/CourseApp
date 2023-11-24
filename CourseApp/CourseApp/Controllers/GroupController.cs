using Domain.Models;
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
            Console.WriteLine("Enter group name");
            Name: string groupName = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(groupName))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Group name is required!");
                goto Name;
            }
            
            var res = _groupService.GetAll();
            foreach( var item in res )
            {
                if( item.Name == groupName )
                {
                    Console.WriteLine("Group name has already exist");
                    goto Name;
                }
            }
            
            Console.WriteLine("Enter group capacity");
            Capacity: string capacityStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Capacity is required!");
                goto Capacity;
            }
            bool IsCorrectFormat = int.TryParse(capacityStr, out int capacity);
            if(!IsCorrectFormat)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Capacity format is wrong, enter correct format");
                goto Capacity;
            }

            _groupService.Create(new Group { Name = groupName , Capacity = capacity });



        }

        public void GetAll()
        {
            var res = _groupService.GetAll();

            foreach(var group in res)
            {
                Console.WriteLine($"**Group name: {group.Name}\n**Group capacity: {group.Capacity}");
            }
        }


        public void Delete()
        {
            Console.WriteLine("Enter the group ID you want to delete: ");
            ID: string groupID = Console.ReadLine();
            bool IsCorrectFormat = int.TryParse(groupID, out int id);

            if (!IsCorrectFormat)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("ID format is wrong,try again");
                goto ID;
            }
            if (!_groupService.Delete(id))
            {
                ConsoleColor.Red.ConsoleWriteLine("Group not found with this ID");
            }
            else
            {
                ConsoleColor.Green.ConsoleWriteLine("Group successfully deleted");
            }
        }

        public void Search()
        {
            Console.WriteLine("Enter group name: ");
            string groupName = Console.ReadLine();

            var res = _groupService.Search(groupName);

            if(res.Count == 0)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Group not found");
                return;
            }

            foreach (var group in res)
            {
                Console.WriteLine($"**Group name: {group.Name}\n**Group capacity: {group.Capacity}");
            }
        }

        public void GetById()
        {
            Console.WriteLine("Enter group ID:");

            ID: bool IsCorrectFormat = int.TryParse(Console.ReadLine(), out int id);
            if (!IsCorrectFormat)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("ID format is wrong,try again");
                goto ID;
            }
            var group = _groupService.GetById(id);

            if (group == null)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Group not found with this ID");
                goto ID;
            }

            Console.WriteLine($"**Group name: {group.Name}\n**Group capacity: {group.Capacity}");


        }

        public void Sort()
        {
            var res = _groupService.Sort();

            foreach (var group in res)
            {
                Console.WriteLine($"**Group name: {group.Name}\n**Group capacity: {group.Capacity}");
            }

        }

        public void Edit()
        {
            Console.WriteLine("Enter group ID of the group you want to edit: ");
            Id: string groupID = Console.ReadLine();

            bool IsCorrectFormat = int.TryParse(groupID, out int id);
            if (IsCorrectFormat)
            {
                var res = _groupService.GetById(id);
                if(res == null)
                {
                    Console.WriteLine("Group not found with this ID,try again");
                    goto Id;
                }
                if(res is not null)
                {
                    Console.WriteLine($"**Group name: {res.Name}\n**Group capacity: {res.Capacity}");

                    Console.WriteLine("Enter group name for change:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter group capacity for change:");
                    string? capacityStr = Console.ReadLine();
                    bool isCorrect = int.TryParse(capacityStr,out int capacity);

                    _groupService.Edit(id, new Group { Name = name, Capacity = capacity });
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
