using EmpMgmtUsingDI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMgmtUsingDI.JsonUtility
{
    public class EmpClassCallUsingDI
    {
        private readonly IEmp _emp;

        public  EmpClassCallUsingDI(IEmp emp)
        {
            _emp = emp;
        }
        public void AddEmp()
        {
            _emp.AddNewEmployee();
        }
        public void UpdateEmp()
        {
            _emp.UpdateEmployeeDetail();
        }
        public void DeleteEmp()
        {
            _emp.DeleteEmployeeDetail();
        }
        public void EmployeeList()
        {
            _emp.AllEmployee();
        }
    }
}
