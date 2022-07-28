using WebApplication1.Models;

namespace WebApplication1.Repositries
{
    public class EmpRep : IEmpRep
    {
        EmployeeDbContext _context;

        public EmpRep(EmployeeDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee obj = _context.Employees.Find(id);
            _context.Employees.Remove(obj);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> epList = _context.Employees.ToList();
            return epList;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee obj = _context.Employees.Find(id);
            return obj;
        }

        public IEnumerable<Employee> GetEmployeeByDeptno(int id)
        {
            IEnumerable<Employee> epList = _context.Employees.Where(item => item.Deptno == id);
            return epList;
        }

        public IEnumerable<Employee> GetEmployeeByJob(string job)
        {
            IEnumerable<Employee> epList = _context.Employees.Where(item => item.Job.Equals(job));
            return epList;
        }

       

        public void UpdateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            _context.SaveChanges();
        }
    }
}