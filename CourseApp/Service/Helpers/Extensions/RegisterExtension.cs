using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class RegisterExtension
    {
        public static bool CheckAtInEmail(this string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(email))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Invalid email format, try again");
                return false;
            }
            return true;
        }


        public static bool ConfirmPassword(this string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Passwords don't match, enter password again");
                return false;
            }
            return true;
        }
    }
}
