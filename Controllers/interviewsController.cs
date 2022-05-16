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
    public class interviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public interviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: interviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.interview.Include(i => i.Application);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: interviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.interview == null)
            {
                return NotFound();
            }

            var interview = await _context.interview
                .Include(i => i.Application)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // GET: interviews/Create
        public IActionResult Create()
        {
            ViewData["ApplicationID"] = new SelectList(_context.application, "ApplicationId", "ApplicationId");
            return View();
        }

        // POST: interviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Start_time,End_time,ApplicationID")] interview interview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationID"] = new SelectList(_context.application, "ApplicationId", "ApplicationId", interview.ApplicationID);
            return View(interview);
        }

        // GET: interviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.interview == null)
            {
                return NotFound();
            }

            var interview = await _context.interview.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }
            ViewData["ApplicationID"] = new SelectList(_context.application, "ApplicationId", "ApplicationId", interview.ApplicationID);
            return View(interview);
        }

        // POST: interviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Start_time,End_time,ApplicationID")] interview interview)
        {
            if (id != interview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!interviewExists(interview.Id))
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
            ViewData["ApplicationID"] = new SelectList(_context.application, "ApplicationId", "ApplicationId", interview.ApplicationID);
            return View(interview);
        }

        // GET: interviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.interview == null)
            {
                return NotFound();
            }

            var interview = await _context.interview
                .Include(i => i.Application)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // POST: interviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.interview == null)
            {
                return Problem("Entity set 'ApplicationDbContext.interview'  is null.");
            }
            var interview = await _context.interview.FindAsync(id);
            if (interview != null)
            {
                _context.interview.Remove(interview);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool interviewExists(int id)
        {
          return _context.interview.Any(e => e.Id == id);
        }
    }
}
