using TravelBooking_NewMVC.Models;

namespace TravelBooking_NewMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Emp_Travel_BookingContext _context;
        public EmployeeRepository(Emp_Travel_BookingContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetEmployees()
        {

            return _context.Employees;
        }
        public void AddEmoloyee(Employee employee)
        {
            if (employee != null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
        }
        public void DeleteEmployee(int id)
        {
             Employee? employee=_context.Employees.FirstOrDefault(x=>x.EmpId == id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            
        }
        public Employee GetEmployeeById(int id)
        {
            Employee?employee=_context.Employees.FirstOrDefault(x=>x.EmpId==id);
            return employee;
            
        }
        public void UpdateEmployee(Employee employee, int id)
        {
            Employee? emp_old = _context.Employees.FirstOrDefault(x => x.EmpId == id);
            if (emp_old != null)
            {
               
                emp_old.EmpFirstName = employee.EmpFirstName;
                emp_old.EmpLastName = employee.EmpLastName;
                emp_old.EmpDob = employee.EmpDob;
                emp_old.EmpAddress = employee.EmpAddress;
                emp_old.EmpContact = employee.EmpContact;

               
                _context.SaveChanges();
            }
        }
    }
}
