using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class NameExtension
    {
        public static bool CheckFirstName(this string text)
        {
            if (Regex.IsMatch(text, "^[A-Z][a-zA-Z]*$"))
            {
                return true;
            }
            ConsoleColor.DarkRed.ConsoleWriteLine("First name format is wrong");
            return false;
        }
        public static bool CheckLastName(this string text)
        {
            if (Regex.IsMatch(text, "^[A-Z][a-zA-Z]*$"))
            {
                return true;
            }
            ConsoleColor.DarkRed.ConsoleWriteLine("First name format is wrong");
            return false;
        }
        public static bool CheckFullName(this string text)
        {
            if (Regex.IsMatch(text, "^[A-Z]\\w+( [A-Z]\\w+)+"))
            {
                return true;
            }
            ConsoleColor.DarkRed.ConsoleWriteLine("Fullname format is wrong");
            return false;
        }
        public static bool CheckAge(this string text)
        {
            if (Regex.IsMatch(text, "^(1[8-9]|[2-9]\\d|\\d{3,})$"))
            {
                return true;
            }
            ConsoleColor.DarkRed.ConsoleWriteLine("Age format is wrong");
            return false;
        }
    }
}
