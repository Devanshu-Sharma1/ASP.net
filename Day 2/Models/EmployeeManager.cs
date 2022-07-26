namespace WebApplication1.Models
{
    public class EmployeeManager
    {
        public List<Employee> Employees = new List<Employee>();
        public EmployeeManager()
        {
            Employees = new List<Employee>() {
                new Employee(){ EmployeeId = 32, EmployeeName = "Priya", Sal = 2400, Deptno = 5 },
                new Employee(){ EmployeeId = 23, EmployeeName = "Ketan", Sal = 1200, Deptno = 3 },
                new Employee(){ EmployeeId = 24, EmployeeName = "Dev", Sal = 900, Deptno = 4 },
                new Employee(){ EmployeeId = 25, EmployeeName = "Travis", Sal = 1500, Deptno = 2 },
                new Employee(){ EmployeeId = 26, EmployeeName = "Ravi", Sal = 800, Deptno = 6 }
            };
        }
        public List<Employee> GetAllDets()
        {
            return Employees;
        }
        public Employee GetEmployeeById(int id)
        {
            return Employees.Find(item => item.EmployeeId == id);
        }
        public void AddEmployee(Employee obj)
        {
            Employees.Add(obj);
        }
        public void DeleteEmployee(int id)
        {
            Employee obj = Employees.Find(item => item.EmployeeId == id);
            Employees.Remove(obj);
        }
        public void UpdateEmployee(Employee updateObj)
        {
            Employee obj = Employees.Find(item => item.EmployeeId == updateObj.EmployeeId);
            Employees.Remove(obj);
            Employees.Add(updateObj);
        }

    }
}
