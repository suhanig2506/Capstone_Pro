using TravelBooking_NewMVC.Models;

namespace TravelBooking_NewMVC.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        void AddEmoloyee(Employee empployee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee, int id);
        Employee GetEmployeeById(int id);
    }
}
