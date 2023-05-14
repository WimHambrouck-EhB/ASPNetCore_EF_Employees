using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Employees.Data;
using ASPNetCore_EF_Employees.Models;

namespace ASPNetCore_EF_Employees.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesContext _context;

        public EmployeesController(EmployeesContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var aSPNetCore_EF_EmployeesContext = _context.Employees.Include(e => e.Department).Include(e => e.Manager);
            return View(await aSPNetCore_EF_EmployeesContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Empno == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), nameof(Department.Deptno), nameof(Department.Name));
            ViewData["Mgr"] = new SelectList(_context.Employees.Where(e => e.Job == Job.Manager), nameof(Employee.Empno), nameof(Employee.Name));
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empno,Name,Job,Mgr,Hiredate,Salary,Commission,Deptno")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), nameof(Department.Deptno), nameof(Department.Name), employee.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Employees.Where(e => e.Job == Job.Manager), nameof(Employee.Empno), nameof(Employee.Name));
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), nameof(Department.Deptno), nameof(Department.Name), employee.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Employees.Where(e => e.Job == Job.Manager), nameof(Employee.Empno), nameof(Employee.Name));
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empno,Name,Job,Mgr,Hiredate,Salary,Commission,Deptno")] Employee employee)
        {
            if (id != employee.Empno)
            {
                return NotFound();
            }

            // check if other employees have this employee as manager
            if (employee.Job != Job.Manager)
            {
                var emps = _context.Employees.Where(e => e.Mgr == employee.Empno);
                if (emps.Any())
                {
                    ModelState.AddModelError(nameof(Employee.Job), "Cannot change job, because this employee is the manager of one or more other employees.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Empno))
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
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), nameof(Department.Deptno), nameof(Department.Name), employee.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Employees.Where(e => e.Job == Job.Manager), nameof(Employee.Empno), nameof(Employee.Name));
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Empno == id);
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
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ASPNetCore_EF_EmployeesContext.Employee'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Empno == id)).GetValueOrDefault();
        }
    }
}
