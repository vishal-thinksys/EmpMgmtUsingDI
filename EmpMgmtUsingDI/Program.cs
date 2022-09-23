// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using EmpMgmtUsingDI.Entity;
using EmpMgmtUsingDI.JsonUtility;
Console.WriteLine("Welcome to Employee Management System!");
int n;
CommanCommandName();
EmpClassCallUsingDI callUsingDI = new EmpClassCallUsingDI(new EmpClass());

while (n > 0)
{
    switch (n)
    {
        case 1:
            callUsingDI.EmployeeList();
            CommanCommandName();
            break;
        case 2:
            callUsingDI.AddEmp();
            CommanCommandName();
            break;
        case 3:
            callUsingDI.UpdateEmp();
            CommanCommandName();
            break;
        case 4:
            callUsingDI.DeleteEmp();
            CommanCommandName();
            break;
        default:
            Console.WriteLine("\nPlease enter correct key\n");
            CommanCommandName();
            break;
    }
}


void CommanCommandName()
{
    Console.WriteLine("\nPress 1 for Show All Employee");
    Console.WriteLine("Press 2 for Add Employee");
    Console.WriteLine("Press 3 for Update Employee");
    Console.WriteLine("Press 4 for Delete Employee");
    Console.Write("Please Enter the Number\t");
    bool isNumerical = int.TryParse(Console.ReadLine(), out n);
    n = isNumerical ? n : 0;
}
