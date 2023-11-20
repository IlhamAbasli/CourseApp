using CourseApp.Controllers;
using Service.Enums;

AccountController accountController = new AccountController();

while (true)
{
    Console.WriteLine("Login (1) or Sign Up (2)");
    string operationStr = Console.ReadLine();

    bool IsCorrectOperation = int.TryParse(operationStr, out int operation);

    switch (operation)
    {
        case (int)AuthenticationTypes.Login:
            accountController.Login();
            break;
        case (int)AuthenticationTypes.Register:
            accountController.Register(); 
            break;
    }
}