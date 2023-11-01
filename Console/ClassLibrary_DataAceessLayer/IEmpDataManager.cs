using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Pro;

namespace ClassLibrary_DataAceessLayer
{
    public interface IEmpDataManager
    {
        int AddEmployee_DAL(int empId, string empName, string Address, DateTime dob,int Contact);

        void ViewEmployee_DAL();
        int EditEmployee_DAL(Employee employee);

        int DeleteEmployee_DAL(int empId);
        
        Employee GetEmployeeById_DAL(int empId);





    }
}
