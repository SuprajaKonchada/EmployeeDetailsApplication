using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeDetailsApplication.Data;
using EmployeeDetailsApplication.Models;
using EmployeeDetailsApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Department> _departmentRepository;

        public EmployeesController(IGenericRepository<Employee> employeeRepository, IGenericRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var appDbContext = _employeeRepository.GetAllAsync();
            return View(await appDbContext);
        }


        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentRepository.GetAllAsync();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,DepartmentId,Details,Experience,EmployeeSkill,EmployeeProject")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.CreateAsync(employee);
                await _employeeRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            var departments = await _departmentRepository.GetAllAsync();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            var departments = await _departmentRepository.GetAllAsync();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,DepartmentId,Details,Experience,EmployeeSkill,EmployeeProject")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.UpdateAsync(employee);
                    await _employeeRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await EmployeeExists(id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var departments = await _departmentRepository.GetAllAsync();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            await _employeeRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EmployeeExists(int id)
        {
            return (await _employeeRepository.GetByIdAsync(id)) != null;
        }
    }
}
