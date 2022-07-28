using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositries;
using log4net;
using System.Diagnostics;
using WebApplication1.Filters;




namespace WebApplication1.Controllers
{
    public class EmpController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IEmpRep _repository;
        public EmpController(IEmpRep repository , ILogger<HomeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }



        [TypeFilter(typeof(MyExceptionFilter))]
        
        public IActionResult Index()
        {
            List<Employee> epList = _repository.GetAllEmployees();
            _logger.LogInformation("Index Action is Processed.");
            



            return View(epList);
        }
        

        [HttpPost]
        [ActionName("EmployeeByDeptno")]
        [TypeFilter(typeof(MyExceptionFilter))]

        public IActionResult EmployeeByDeptno(int id)
        {
            _logger.LogInformation("Employee by deptno is Processed.");

            IEnumerable<Employee> epList = _repository.GetEmployeeByDeptno(id);
            return View(epList);
        }

        [HttpPost]
        [ActionName("EmployeeByJob")]
        [TypeFilter(typeof(MyExceptionFilter))]

        public IActionResult EmployeeByJob(string job)
        {
            _logger.LogInformation("Employee by job is Processed.");
            IEnumerable<Employee> epList = _repository.GetEmployeeByJob(job);
            return View(epList);
        }

        [HttpGet]
        
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create()
        {
            _logger.LogInformation("Create get action is processed");

            return View();
        }

        [HttpPost]
        
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create(Employee obj)
        {
            _logger.LogInformation("create post action is processed");
            _repository.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details action is processed");
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }


        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Edit get action is processed");
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(Employee obj)
        {
            _logger.LogInformation("Edit post action is processed");
            _repository.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete get action is processed");
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]

        [TypeFilter(typeof(MyExceptionFilter))]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _logger.LogInformation("Delete post action is processed");
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}