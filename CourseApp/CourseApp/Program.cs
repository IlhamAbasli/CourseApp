using CourseApp.Controllers;
using Service.Enums;

AccountController accountController = new AccountController();
GroupController groupController = new GroupController();
StudentController studentController = new StudentController();

//while (true)
//{
//    Console.WriteLine("Login (1) or Sign Up (2)");
//    string operationStr = Console.ReadLine();

//    bool IsCorrectOperation = int.TryParse(operationStr, out int operation);

//    switch (operation)
//    {
//        case (int)AuthenticationTypes.Login:
//            accountController.Login();
//            goto Menu;

//        case (int)AuthenticationTypes.Register:
//            accountController.Register(); 
//            break;
//    }

//}

/*Menu:*/ Console.WriteLine("Welcome our application");
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
    Console.WriteLine("\nChoose one option:\nGroup operations:\n(1) Create group\n(2) Delete group\n(3) Edit group\n(4) Get group by ID\n(5) Show all groups\n(6) Search groups\n(7) Sort groups\n\n**********************************\n\n(8) Add student\n(9) Delete student\n(10) Edit student\n(11) Get student by ID\n(12) Show all students\n(13) Search students\n(14) Sort students");
}