using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositries;


namespace WebApplication1.Controllers
{
    public class EmpController : Controller
    {
        IEmpRep _repository;

        public EmpController(IEmpRep repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Employee> epList = _repository.GetAllEmployees();
            return View(epList);
        }

        [HttpPost]
        public IActionResult EmployeeByDeptno(int id)
        {
            IEnumerable<Employee> epList = _repository.GetEmployeeByDeptno(id);
            return View(epList);
        }

        [HttpPost]
        public IActionResult EmployeeByJob(string job)
        {
            IEnumerable<Employee> epList = _repository.GetEmployeeByJob(job);
            return View(epList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _repository.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _repository.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}