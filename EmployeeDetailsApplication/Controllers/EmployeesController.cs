using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeDetailsApplication.Data;
using EmployeeDetailsApplication.Models;
using EmployeeDetailsApplication.Repositories;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll()
                                               .Include(e => e.Department) // Eager load the Department
                                               .ToList();
            return View(employees);
        }


        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Eagerly load the Department navigation property
            var employee = _employeeRepository.GetAll()
                                              .Include(e => e.Department) // Include the Department
                                              .FirstOrDefault(e => e.EmployeeId == id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        // GET: Employees/Create
        public IActionResult Create()
        {
            var departments = _departmentRepository.GetAll();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeId,Name,DepartmentId,Details,Experience,EmployeeSkill,EmployeeProject")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Create(employee);
                _employeeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            var departments = _departmentRepository.GetAll();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            var departments = _departmentRepository.GetAll();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EmployeeId,Name,DepartmentId,Details,Experience,EmployeeSkill,EmployeeProject")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Update(employee);
                    _employeeRepository.Save(); // Ensure Save() commits changes
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Rethrow the exception for further investigation
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // If we reach this point, it means the model state is invalid
            var departments = _departmentRepository.GetAll();
            ViewData["DepartmentName"] = new SelectList(departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }


        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Eagerly load the Department navigation property
            var employee = _employeeRepository.GetAll()
                                              .Include(e => e.Department) // Include the Department
                                              .FirstOrDefault(e => e.EmployeeId == id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _employeeRepository.GetById(id) != null;
        }
        

    }
}
