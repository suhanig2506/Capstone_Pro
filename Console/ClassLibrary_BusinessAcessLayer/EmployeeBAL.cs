using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_DataAceessLayer;
using Final_Pro;

namespace ClassLibrary_BusinessAcessLayer
{
    public class EmployeeBAL:IEmployeeBAL
    {
        
        private static readonly EmpDataManager emp = new EmpDataManager();
        public int AddEmployee_BAL(int empId, string empName, string Address, DateTime dob,int Contact)
            {
                
                emp.AddEmployee_DAL(empId,empName,Address,dob,Contact);
            
                return 1;

            }
            public void ViewEmployee_BAL()
            {
               
                emp.ViewEmployee_DAL();
            }
            
            public int DeleteEmployee_BAL(int empId)
            {
                
                emp.DeleteEmployee_DAL(empId);
                return 1;
        }
        public Employee GetEmployeeById(int empId)
        {
            
            Employee emp1=emp.GetEmployeeById_DAL(empId);
            return emp1;
        }
         public void EditEmployee_BAL(Employee emp_to_change)
        { 
            emp.EditEmployee_DAL(emp_to_change);
        }

        }
    
}
