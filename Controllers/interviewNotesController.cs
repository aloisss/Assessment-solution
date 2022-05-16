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
    public class interviewNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public interviewNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: interviewNotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.interviewNotes.Include(i => i.Interview);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: interviewNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.interviewNotes == null)
            {
                return NotFound();
            }

            var interviewNotes = await _context.interviewNotes
                .Include(i => i.Interview)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewNotes == null)
            {
                return NotFound();
            }

            return View(interviewNotes);
        }

        // GET: interviewNotes/Create
        public IActionResult Create()
        {
            ViewData["InterviewId"] = new SelectList(_context.interview, "Id", "Id");
            return View();
        }

        // POST: interviewNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pass,InterviewId")] interviewNotes interviewNotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interviewNotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InterviewId"] = new SelectList(_context.interview, "Id", "Id", interviewNotes.InterviewId);
            return View(interviewNotes);
        }

        // GET: interviewNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.interviewNotes == null)
            {
                return NotFound();
            }

            var interviewNotes = await _context.interviewNotes.FindAsync(id);
            if (interviewNotes == null)
            {
                return NotFound();
            }
            ViewData["InterviewId"] = new SelectList(_context.interview, "Id", "Id", interviewNotes.InterviewId);
            return View(interviewNotes);
        }

        // POST: interviewNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pass,InterviewId")] interviewNotes interviewNotes)
        {
            if (id != interviewNotes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interviewNotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!interviewNotesExists(interviewNotes.Id))
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
            ViewData["InterviewId"] = new SelectList(_context.interview, "Id", "Id", interviewNotes.InterviewId);
            return View(interviewNotes);
        }

        // GET: interviewNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.interviewNotes == null)
            {
                return NotFound();
            }

            var interviewNotes = await _context.interviewNotes
                .Include(i => i.Interview)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewNotes == null)
            {
                return NotFound();
            }

            return View(interviewNotes);
        }

        // POST: interviewNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.interviewNotes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.interviewNotes'  is null.");
            }
            var interviewNotes = await _context.interviewNotes.FindAsync(id);
            if (interviewNotes != null)
            {
                _context.interviewNotes.Remove(interviewNotes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool interviewNotesExists(int id)
        {
          return _context.interviewNotes.Any(e => e.Id == id);
        }
    }
}
