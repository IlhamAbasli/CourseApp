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
            if (!email.Contains("@"))
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Email must contain '@', try again");
                return false;
            }
            int count = 0;
            foreach (char c in email)
            {
                if (c == '@')
                {
                    count++;
                }
                if(count > 1)
                {
                    ConsoleColor.DarkRed.ConsoleWriteLine("Invalid email format, try again");
                    return false;
                }
            }
            return true;
        }


        public static bool ConfirmPassword(this string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                ConsoleColor.DarkRed.ConsoleWriteLine("Passwords don't match");
                return false;
            }
            return true;
        }
    }
}
