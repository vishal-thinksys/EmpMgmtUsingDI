using EmpMgmtUsingDI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMgmtUsingDI.OutputPrint
{
    public class PrintEmpList
    {
        public static void PrintDetail(List<Employee> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"ID    ={list[i].EmpID}");
                Console.WriteLine($"Name  ={list[i].Name}");
                Console.WriteLine($"DOB   ={list[i].DOB:D}");
                Console.WriteLine($"Email ={list[i].EmailId}");
                Console.WriteLine($"Mobile={list[i].MobileNo}");
                Console.WriteLine($"Salary={list[i].Salary.ToString()}");
                Console.WriteLine($"Date of Joinning={list[i].DOJ:D}");
                Console.WriteLine("");
            }

        }
    }
}
