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
    internal class AccountController
    {
        private readonly IAccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        public void Register()
        {
            Console.WriteLine("First name: ");
            FirstName:  string firstName = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(firstName))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("First name is required!");
                goto FirstName;
            }

            Console.WriteLine("Last name: ");
            LastName: string lastName = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(lastName))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Last name is required!");
                goto LastName;
            }

            Console.WriteLine("Age: ");
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

            Console.WriteLine("Email: ");
            Email: string email = Console.ReadLine();
           
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Email field is required!");
                goto Email;
            }else if (!email.CheckAtInEmail())
            {
                goto Email;
            }
            else
            {
                email.CheckAtInEmail();
            }
            

            Console.WriteLine("Password: ");
            Password: string password = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Password is required!");
                goto Password;
            }

            Console.WriteLine("Confirm password: ");
            ConfirmationPassword: string confirmPassword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Confirmation password is required!");
                goto ConfirmationPassword;
            }
            if (!password.ConfirmPassword(confirmPassword))
            {
                goto ConfirmationPassword;
            }

            

            _accountService.Register(new Domain.Models.User { Name = firstName, Surname = lastName , Age = age ,Email = email, Password = password, });
            ConsoleColor.DarkGreen.ConsoleWriteLine("Account successfully created");
        }

        public void Login()
        {
            Console.WriteLine("Enter your email: ");
            Email: string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Email field is required!");
                goto Email;
            }
            else if (!email.CheckAtInEmail())
            {
                goto Email;
            }
            else
            {
                email.CheckAtInEmail();
            }

            Console.WriteLine("Enter your password");
            Password: string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Password is required!");
                goto Password;
            }

            var res = _accountService.Login(email, password);
            if (!res)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Email or password is wrong, try again enter your email");
                goto Email;
            }
            else
            {
                ConsoleColor.Green.ConsoleWriteLine("Login successfull");
            }


        }
    }
}
