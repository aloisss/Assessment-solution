using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Models;

namespace Recruitment.Controllers
{
    public class application_testController : Controller
    {
        private readonly ApplicationDbContext _context;

        public application_testController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: application_test
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.application_test.Include(a => a.Application).Include(a => a.Test);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: application_test/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.application_test == null)
            {
                return NotFound();
            }

            var application_test = await _context.application_test
                .Include(a => a.Application)
                .Include(a => a.Test)
                .FirstOrDefaultAsync(m => m.ApplicationTestId == id);
            if (application_test == null)
            {
                return NotFound();
            }

            return View(application_test);
        }

        // GET: application_test/Create
        public IActionResult Create()
        {
            ViewData["ApplicationId"] = new SelectList(_context.application, "ApplicationId", "ApplicationId");
            ViewData["TestId"] = new SelectList(_context.Set<test>(), "TestId", "TestId");
            return View();
        }

        // POST: application_test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationTestId,ApplicationId,Starting_day,Ending_day,TestId")] application_test application_test)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application_test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.application, "ApplicationId", "ApplicationId", application_test.ApplicationId);
            ViewData["TestId"] = new SelectList(_context.Set<test>(), "TestId", "TestId", application_test.TestId);
            return View(application_test);
        }

        // GET: application_test/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.application_test == null)
            {
                return NotFound();
            }

            var application_test = await _context.application_test.FindAsync(id);
            if (application_test == null)
            {
                return NotFound();
            }
            ViewData["ApplicationId"] = new SelectList(_context.application, "ApplicationId", "ApplicationId", application_test.ApplicationId);
            ViewData["TestId"] = new SelectList(_context.Set<test>(), "TestId", "TestId", application_test.TestId);
            return View(application_test);
        }

        // POST: application_test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationTestId,ApplicationId,Starting_day,Ending_day,TestId")] application_test application_test)
        {
            if (id != application_test.ApplicationTestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application_test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!application_testExists(application_test.ApplicationTestId))
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
            ViewData["ApplicationId"] = new SelectList(_context.application, "ApplicationId", "ApplicationId", application_test.ApplicationId);
            ViewData["TestId"] = new SelectList(_context.Set<test>(), "TestId", "TestId", application_test.TestId);
            return View(application_test);
        }

        // GET: application_test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.application_test == null)
            {
                return NotFound();
            }

            var application_test = await _context.application_test
                .Include(a => a.Application)
                .Include(a => a.Test)
                .FirstOrDefaultAsync(m => m.ApplicationTestId == id);
            if (application_test == null)
            {
                return NotFound();
            }

            return View(application_test);
        }

        // POST: application_test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.application_test == null)
            {
                return Problem("Entity set 'ApplicationDbContext.application_test'  is null.");
            }
            var application_test = await _context.application_test.FindAsync(id);
            if (application_test != null)
            {
                _context.application_test.Remove(application_test);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool application_testExists(int id)
        {
          return _context.application_test.Any(e => e.ApplicationTestId == id);
        }
    }
}
