using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Pro
{
    public class Employee
    {
        public int empId { get; set; }
        public string EmpName { get; set; }
        public DateTime dob { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }

        //public Employee(int empId, string empName, string address, DateTime dob)
        //{
        //    this.empId = empId;
        //    EmpName = empName;
        //    Address = address;
        //    this.dob = dob;

        //}

        public override string ToString()
        {
            
            return string.Format("{0,-10} {1,-10} {2,-10}  {3,-15}\t {4,-20}"
      , empId, EmpName, Address,dob,Contact);
        }

    }   
}
