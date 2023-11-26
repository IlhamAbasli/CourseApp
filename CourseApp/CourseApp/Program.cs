using CourseApp.Controllers;
using Domain.Models;
using Service.Enums;
using Service.Helpers.Extensions;
using Spectre.Console;
using System.Xml;

AccountController accountController = new AccountController();
GroupController groupController = new GroupController();
StudentController studentController = new StudentController();

while (true)
{
    ConsoleColor.DarkYellow.ConsoleWriteLine("Login (1) or Sign Up (2)");
    Operation: string operationStr = Console.ReadLine();
    bool IsCorrectOperation = int.TryParse(operationStr, out int operation);

    switch (operation)
    {
        case (int)AuthenticationTypes.Login:
            accountController.Login();
            goto Menu;

        case (int)AuthenticationTypes.Register:
            accountController.Register();
            break;
        default:
            ConsoleColor.DarkRed.ConsoleWriteLine("Invalid operation, try again");
            goto Operation;
    }

}
Menu:
Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
int width = Console.WindowWidth;
int height = Console.WindowHeight;

string message = "WELCOME TO MY APPLICATION!";


int x = (width - message.Length) / 2;
int y = height / 2;


Console.SetCursorPosition(x, y);
Console.WriteLine(message);

int num = 1;

while (true)
{
    num = (num % 9) + 1;
    System.Threading.Thread.Sleep(1000);
    if (num == 4)
    {
        Console.Clear();
        break;
    }
}

Console.Clear();
AnsiConsole.Write(new FigletText("Classroom").Centered().Color(Color.Lime));
AnsiConsole.Write(new FigletText("application").Centered().Color(Color.Lime));
while (true)
{
    Menu();
    Operation: string appOperationStr = Console.ReadLine();
    bool IsCorrectOperation = int.TryParse(appOperationStr, out int appOperation);

    switch (appOperation)
    {
        
        case (int)OperationTypes.GroupCreate:
            groupController.Create();
            break;
        case (int)OperationTypes.GroupDelete:
            groupController.Delete();
            break;
        case (int)OperationTypes.GroupEdit:
            groupController.Edit();
            break;
        case (int)OperationTypes.GroupGetById:
            groupController.GetById();
            break;
        case (int)OperationTypes.GroupGetAll:
            groupController.GetAll();
            break;
        case (int)OperationTypes.GroupSearch:
            groupController.Search();
            break;
        case (int)OperationTypes.GroupSorting:
            groupController.Sort();
            break;
        case (int)OperationTypes.StudentCreate:
            studentController.Create();
            break;
        case (int)OperationTypes.StudentDelete:
            studentController.Delete();
            break;
        case (int)OperationTypes.StudentEdit:
            studentController.Edit();
            break;
        case (int)OperationTypes.StudentGetById:
            studentController.GetById();
            break;
        case (int)OperationTypes.StudentGetAll:
            studentController.GetAll();
            break;
        case (int)OperationTypes.StudentSearch:
            studentController.Search();
            break;
        case (int)OperationTypes.StudentSorting:
            studentController.Sort();
            break;
        default:
            Console.WriteLine("Invalid operation,try again");
            goto Operation;


    }
}




static void Menu()
{
    ConsoleColor.DarkBlue.ConsoleWriteLine("\nChoose one option:\n*Group operations:\n(1) Create group\n(2) Delete group\n(3) Edit group\n(4) Get group by ID\n(5) Show all groups\n(6) Search groups\n(7) Sort groups");
    ConsoleColor.DarkRed.ConsoleWriteLine("\n***********************************\n");
    ConsoleColor.DarkGreen.ConsoleWriteLine("*Student operations:\n(8) Add student\n(9) Delete student\n(10) Edit student\n(11) Get student by ID\n(12) Show all students\n(13) Search students\n(14) Sort students");
}