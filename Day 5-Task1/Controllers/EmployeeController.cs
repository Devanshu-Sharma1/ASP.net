using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var Employees = await _context.Employees.ToListAsync();
            if (Employees.Count > 0)
            {
                return Ok(Employees);

            }
            else
            {
                return Ok("No Employee exist in database");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var Employees = await _context.Employees.FindAsync(id);

            if (Employees != null)
            {
                return Ok(Employees);
            }
            else
            {
                return NotFound("Requested Employee Id does not exists.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            await _context.Employees.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok("New Employee details are saved in database.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            await _context.SaveChangesAsync();
            return Ok("Employee details are updated in database.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var obj = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(obj);
            await _context.SaveChangesAsync();
            return Ok("Employee details are deleted from database.");
        }
    }
}