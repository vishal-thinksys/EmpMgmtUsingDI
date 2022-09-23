using EmpMgmtUsingDI.Entity;
using EmpMgmtUsingDI.Interface;
using EmpMgmtUsingDI.OutputPrint;
using Newtonsoft.Json;
using System.Globalization;

namespace EmpMgmtUsingDI.JsonUtility
{
    public class EmpClass : IEmp
    {
        string fileName;
        public EmpClass()
        {
            string folderName = @"C:\Users\kumar.vishal\Desktop\Vishal\EmpMgmtUsingDI\EmpMgmtUsingDI\EmployeeData";
            fileName = Path.Combine(folderName, "JSONFile.json");
        }
        public void AddNewEmployee()
        {
            if (File.Exists(fileName))
            {
                bool temp;
                string Json = File.ReadAllText(fileName);
                List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(Json) ?? new List<Employee>();
                list = list.OrderBy(X => X.EmpID).ToList();
                int count = list.Count();
                Employee emp = new Employee();
                emp.EmpID = list[count - 1].EmpID + 1;
                do
                {
                    Console.WriteLine("Please Enter Employee Name:\t");
                    emp.Name = Console.ReadLine() ?? "";
                } while (emp.Name == "");
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee DOB (dd-mm-yyyy):\t");
                    DateTime dat;
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat))
                    {
                        temp = false;
                        emp.DOB = dat;
                    }
                } while (temp);
                do
                {
                    Console.WriteLine("Please Enter Employee EmailId:\t");
                    emp.EmailId = Console.ReadLine() ?? "";
                } while (emp.EmailId == "");
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee MobileNo:\t");
                    string mob = Console.ReadLine() ?? "";
                    if (mob.Length == 10)
                    {
                        double r;
                        if (double.TryParse(mob, out r))
                        {
                            if (JsonConvert.DeserializeObject<List<Employee>>(Json).Where(x => x.MobileNo == mob).ToList().Count == 0)
                            {
                                temp = false;
                                emp.MobileNo = mob;
                            }
                        }
                    }
                } while (temp);
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee Salary:\t");
                    string salary = Console.ReadLine() ?? "";
                    double sal;
                    if (double.TryParse(salary, out sal))
                    {
                        temp = false;
                        emp.Salary = sal;
                    }
                } while (temp);
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee DOJ (dd-mm-yyyy):\t");
                    DateTime dat;
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat))
                    {
                        temp = false;
                        emp.DOJ = dat;
                    }
                } while (temp);
                list.Add(emp);
                var setting = new JsonSerializerSettings() { DateFormatString = "MM'-'dd'-'yyyy" };
                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented, setting);
                using (FileStream fs = new FileStream(fileName, FileMode.Truncate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(serializedJson);
                    }
                }
            }
            else
            {
                bool temp;
                List<Employee> list = new List<Employee>();
                Employee emp = new Employee();
                emp.EmpID = 1;
                do
                {
                    Console.WriteLine("Please Enter Employee Name:\t");
                    emp.Name = Console.ReadLine() ?? "";
                } while (emp.Name == "");
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee DOB (dd-mm-yyyy):\t");
                    DateTime dat;
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat))
                    {
                        temp = false;
                        emp.DOB = dat;
                    }
                } while (temp);
                do
                {
                    Console.WriteLine("Please Enter Employee EmailId:\t");
                    emp.EmailId = Console.ReadLine() ?? "";
                } while (emp.EmailId == "");
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee MobileNo:\t");
                    string mob = Console.ReadLine() ?? "";
                    if (mob.Length == 10)
                    {
                        double r;
                        if (double.TryParse(mob, out r))
                        {
                                temp = false;
                                emp.MobileNo = mob;
                           
                        }
                    }
                } while (temp);
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee Salary:\t");
                    string salary = Console.ReadLine() ?? "";
                    double sal;
                    if (double.TryParse(salary, out sal))
                    {
                        temp = false;
                        emp.Salary = sal;
                    }
                } while (temp);
                do
                {
                    temp = true;
                    Console.WriteLine("Please Enter Employee DOJ (dd-mm-yyyy):\t");
                    DateTime dat;
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat))
                    {
                        temp = false;
                        emp.DOJ = dat;
                    }
                } while (temp);
                list.Add(emp);
                var setting = new JsonSerializerSettings() { DateFormatString = "MM'-'dd'-'yyyy" };
                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented, setting);
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(serializedJson);
                    }
                }
                //Console.WriteLine("Json File does not exist!");
            }
            AllEmployee();
        }

        public void AllEmployee()
        {
            if (File.Exists(fileName))
            {
                string Json = File.ReadAllText(fileName);
                List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(Json);
                PrintEmpList.PrintDetail(emp);
            }
            else
            {
                Console.WriteLine("Json File does not exist!");
            }
        }

        public void DeleteEmployeeDetail()
        {
            if (File.Exists(fileName))
            {
                string Json = File.ReadAllText(fileName);
                List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(Json) ?? new List<Employee>();
                Console.WriteLine("Please Enter EmpID Which you want to delete:");
                int m = int.TryParse(Console.ReadLine(), out m) ? m : 0;
                emp= emp.Where(x => x.EmpID == m).ToList();
                if (emp.Count > 0)
                {
                    PrintEmpList.PrintDetail(emp);
                    Console.WriteLine("Press 1 for Delete Employee record");
                    int n = int.TryParse(Console.ReadLine(), out n) ? n : 0;
                    if (n==1)
                    {
                        Console.WriteLine("Are you sure want to delete then press y");
                        if (Console.ReadLine() == "y")
                        {
                            Employee empl = new Employee();
                            ReWriteInJsonFile(Json, m, empl);
                        }
                        else
                            Console.WriteLine("You are enter wrong key");
                    }                  
                    else
                        Console.WriteLine("You are enter wrong key");
                }
            }
        }
      
        public void UpdateEmployeeDetail()
        {
            if (File.Exists(fileName))
            {
                string Json = File.ReadAllText(fileName);
                List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(Json) ?? new List<Employee>();
                Console.WriteLine("Please Enter EmpID Which you want to update:");
                int m = int.TryParse(Console.ReadLine(), out m) ? m : 0;
                emp=emp.Where(x => x.EmpID == m).ToList();
                if (emp.Count > 0)
                {
                    PrintEmpList.PrintDetail(emp);
                    Console.WriteLine("Press 1 for Name");
                    Console.WriteLine("Press 2 for DOB");
                    Console.WriteLine("Press 3 for EmailId");
                    Console.WriteLine("Press 4 for MobileNo");
                    Console.WriteLine("Press 5 for Salary");
                    Console.WriteLine("Press 6 for DOJ");
                    Console.WriteLine("Press 7 for Delete Employee record");
                    Console.WriteLine("Please Enter the number:");
                    int n = int.TryParse(Console.ReadLine(), out n) ? n : 0;
                    Employee empl;
                    switch (n)
                    {
                        case 1:
                            Console.WriteLine("Please Enter New Name:");
                            empl = emp.Where(x => x.EmpID == m).Select(y => { y.Name = Console.ReadLine() ?? ""; return y; }).FirstOrDefault() ?? new Employee();
                            ReWriteInJsonFile(Json, m, empl);

                            break;
                        case 2:
                            Console.WriteLine("Please Enter New DOB(dd-mm-yyyy):");
                            DateTime d;
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                            {
                                empl = emp.Where(x => x.EmpID == m).Select(y => { y.DOB = Convert.ToDateTime(d); return y; }).FirstOrDefault() ?? new Employee();
                                ReWriteInJsonFile(Json, m, empl);

                            }
                            else
                                Console.WriteLine("You are enter wrong Date");
                            break;
                        case 3:
                            Console.WriteLine("Please Enter New EmailId:");
                            string Email = Console.ReadLine() ?? "";
                            Email = Email.Trim();
                            if (Email.Length > 0)
                            {
                                if (JsonConvert.DeserializeObject<List<Employee>>(Json).Where(x => x.EmailId.ToUpper() == Email.ToUpper()).ToList().Count == 0)
                                {
                                    empl = emp.Where(x => x.EmpID == m).Select(y => { y.EmailId = Email; return y; }).FirstOrDefault() ?? new Employee();
                                    ReWriteInJsonFile(Json, m, empl);
                                }
                                else
                                {
                                    Console.WriteLine("Email Already Exist!!!");
                                }
                            }
                            else
                                Console.WriteLine("You are not enter any email!");
                            break;
                        case 4:
                            Console.WriteLine("Please Enter New MobileNo:");
                            string mob = Console.ReadLine() ?? "";
                            if (mob.Length == 10)
                            {
                                double r;
                                if (double.TryParse(mob, out r))
                                {
                                    if (JsonConvert.DeserializeObject<List<Employee>>(Json).Where(x => x.MobileNo == mob).ToList().Count == 0)
                                    {
                                        empl = emp.Where(x => x.EmpID == m).Select(y => { y.MobileNo = mob; return y; }).FirstOrDefault() ?? new Employee();
                                        ReWriteInJsonFile(Json, m, empl);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Mobile Number Already Exist!!!");
                                    }

                                }
                                else
                                    Console.WriteLine("Please Enter Valid Mobile No");
                            }
                            else
                                Console.WriteLine("Please Enter Valid Mobile No");
                            break;
                        case 5:
                            Console.WriteLine("Please Enter New Salary:");
                            string salary = Console.ReadLine() ?? "";
                            double sal;
                            if (double.TryParse(salary, out sal))
                            {
                                empl = emp.Where(x => x.EmpID == m).Select(y => { y.Salary = sal; return y; }).FirstOrDefault() ?? new Employee();
                                ReWriteInJsonFile(Json, m, empl);

                            }
                            else
                                Console.WriteLine("Please Enter Valid Amount");
                            break;
                        case 6:
                            Console.WriteLine("Please Enter New DOJ (dd-mm-yyyy):");
                            DateTime dat;
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat))
                            {
                                empl = emp.Where(x => x.EmpID == m).Select(y => { y.DOJ = Convert.ToDateTime(dat); return y; }).FirstOrDefault() ?? new Employee();
                                ReWriteInJsonFile(Json, m, empl);
                            }
                            else
                                Console.WriteLine("You are enter wrong Date");
                            break;                       
                        default:
                            Console.WriteLine("You are enter Wrong Number");
                            break;
                    }
                }
                else
                    Console.WriteLine($"EmpID {m} does not exist in the Json file ");
            }
            else
            {
                Console.WriteLine("Json File does not exist!");
            }
        }
        void ReWriteInJsonFile(string Json, int id, Employee emp)
        {
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(Json) ?? new List<Employee>();
            employees = employees.Where(x => x.EmpID != id).ToList();
            if (emp.EmpID != 0)
                employees.Add(emp);
            employees = employees.OrderBy(X => X.EmpID).ToList();
            var setting = new JsonSerializerSettings() { DateFormatString = "MM'-'dd'-'yyyy" };
            string serializedJson = JsonConvert.SerializeObject(employees, Formatting.Indented, setting);
            using (FileStream fs = new FileStream(fileName, FileMode.Truncate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(serializedJson);
                }
            }
            PrintEmpList.PrintDetail(employees);
        }
    }
}
