using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebOS.Data;
using WebOS.Models;

namespace WebOS.Controllers
{
    public class DepartmentRanksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentRanks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DepartmentRank.Include(d => d.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DepartmentRanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentRank == null)
            {
                return NotFound();
            }

            var departmentRank = await _context.DepartmentRank
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentRank == null)
            {
                return NotFound();
            }

            return View(departmentRank);
        }

        // GET: DepartmentRanks/Create
        public IActionResult Create(int DepartmentId)
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department.Where(d=>d.Id== DepartmentId), "Id", "ArFacultyName");
            return View();
        }

        // POST: DepartmentRanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AcademicReputation,EmployerReputation,Citations,InternationalStudentRatio,DepartmentId")] DepartmentRank departmentRank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentRank);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Departments");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "ArFacultyName", departmentRank.DepartmentId);
            return View(departmentRank);
        }

        // GET: DepartmentRanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentRank == null)
            {
                return NotFound();
            }

            var departmentRank = await _context.DepartmentRank.FindAsync(id);
            if (departmentRank == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "ArFacultyName", departmentRank.DepartmentId);
            return View(departmentRank);
        }

        // POST: DepartmentRanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AcademicReputation,EmployerReputation,Citations,InternationalStudentRatio,DepartmentId")] DepartmentRank departmentRank)
        {
            if (id != departmentRank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentRankExists(departmentRank.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Departments");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "ArFacultyName", departmentRank.DepartmentId);
            return View(departmentRank);
        }

        // GET: DepartmentRanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentRank == null)
            {
                return NotFound();
            }

            var departmentRank = await _context.DepartmentRank
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentRank == null)
            {
                return NotFound();
            }

            return View(departmentRank);
        }

        // POST: DepartmentRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentRank == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DepartmentRank'  is null.");
            }
            var departmentRank = await _context.DepartmentRank.FindAsync(id);
            if (departmentRank != null)
            {
                _context.DepartmentRank.Remove(departmentRank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentRankExists(int id)
        {
          return _context.DepartmentRank.Any(e => e.Id == id);
        }
    }
}
