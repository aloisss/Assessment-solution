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
    public class applicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public applicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: applications
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.application.ToListAsync());


        }

        // GET: applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.application == null)
            {
                return NotFound();
            }

            var application = await _context.application
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,ApplicantName,Date_of_application,Education,Experience")] application application)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        // GET: applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.application == null)
            {
                return NotFound();
            }

            var application = await _context.application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        // POST: applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,ApplicantName,Date_of_application,Education,Experience")] application application)
        {
            if (id != application.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!applicationExists(application.ApplicationId))
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
            return View(application);
        }

        // GET: applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.application == null)
            {
                return NotFound();
            }

            var application = await _context.application
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.application == null)
            {
                return Problem("Entity set 'ApplicationDbContext.application'  is null.");
            }
            var application = await _context.application.FindAsync(id);
            if (application != null)
            {
                _context.application.Remove(application);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool applicationExists(int id)
        {
          return _context.application.Any(e => e.ApplicationId == id);
        }
    }
}
