using EmpMgmtUsingDI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMgmtUsingDI.Interface
{
    public interface IEmp
    {
        void AllEmployee();
        void AddNewEmployee();
        void UpdateEmployeeDetail();
        void DeleteEmployeeDetail();
    }
}
