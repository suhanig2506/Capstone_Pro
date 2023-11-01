using Final_Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_BusinessAcessLayer
{
    public interface IEmployeeBAL
    {
        int AddEmployee_BAL(int empId, string empName, string Address, DateTime dob, int Contact);

        void ViewEmployee_BAL();
        //int EditEmployee_BAL(Employee employee);

         Employee GetEmployeeById(int empId);
        void EditEmployee_BAL(Employee emp_to_change);
        int DeleteEmployee_BAL(int empId);
    }
}
