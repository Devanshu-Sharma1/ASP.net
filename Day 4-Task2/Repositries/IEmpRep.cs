using WebApplication1.Models;

namespace WebApplication1.Repositries
{
    public interface IEmpRep
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetEmployeeByDeptno(int id);
        IEnumerable<Employee> GetEmployeeByJob(string job);
        void AddEmployee(Employee obj);
        void UpdateEmployee(Employee obj);
        void DeleteEmployee(int id);
    }
}
