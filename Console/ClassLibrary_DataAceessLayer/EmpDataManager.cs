using Final_Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace ClassLibrary_DataAceessLayer
    
{
    public class EmpDataManager : IEmpDataManager
    {

        public List<Employee> lstEmployees = new List<Employee>()
        {
          new Employee() { empId = 1, EmpName = "Suhani",Address="pune", dob = DateTime.Parse("03-06-1908"),Contact=992149},
          new Employee() { empId = 2,EmpName = "Tanya",Address="pune",dob = DateTime.Parse("24-05-2002"),Contact=992149},
          new Employee() { empId = 3,EmpName = "Ashwini",Address = "pune", dob = DateTime.Parse("30-06-2002"),Contact=992149}
    };


        public int AddEmployee_DAL(int empId, string empName, string Address, DateTime dob,int Contact)

        {
            Employee emp = new Employee() { empId = empId, EmpName = empName, dob = dob,Contact=Contact};
            Console.WriteLine(emp.ToString());
            return 1;
            
        }
        public void ViewEmployee_DAL()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View All Employees");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-18}\t {4,-20}", "Emp Id", "Name",  "Address",  "DOB\t", "Conatct");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (Employee emp in lstEmployees)
            {
                Console.WriteLine(emp.ToString());
            }
            //Console.ReadLine();
        }
            
        public int EditEmployee_DAL(Employee emp)
        {
            int index=lstEmployees.IndexOf(lstEmployees.FirstOrDefault(X=> X.empId==emp.empId));
            lstEmployees[index].EmpName = emp.EmpName;
            lstEmployees[index].Address = emp.Address;
            lstEmployees[index].dob=emp.dob;
            Console.WriteLine("In-Edit DAL");
            //ViewEmployee_DAL();
            
            
            return 1;
        }
        public Employee GetEmployeeById_DAL(int empId)
        {
            Employee employee=lstEmployees.FirstOrDefault(e=>e.empId == empId);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }
        
        public int DeleteEmployee_DAL(int empId)
        {
            ViewEmployee_DAL();
            var empDel = lstEmployees.Remove(lstEmployees.FirstOrDefault(emp => emp.empId == empId));
            Console.WriteLine("Employee with ID Deleted " + empId );
            ViewEmployee_DAL();
            
            return 1;
       
        }
               
    }



    }

