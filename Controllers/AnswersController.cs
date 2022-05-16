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
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Answers.Include(a => a.ApplicationTest);

           
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Answers == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers
                .Include(a => a.ApplicationTest)
                .FirstOrDefaultAsync(m => m.AnswersId == id);
            if (answers == null)
            {
                return NotFound();
            }

            return View(answers);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            ViewData["ApplicationTestId"] = new SelectList(_context.Set<application_test>(), "ApplicationTestId", "ApplicationTestId");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswersId,Total_grades,Pass,Answer_details,ApplicationTestId")] Answers answers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationTestId"] = new SelectList(_context.Set<application_test>(), "ApplicationTestId", "ApplicationTestId", answers.ApplicationTestId);
            return View(answers);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Answers == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers.FindAsync(id);
            if (answers == null)
            {
                return NotFound();
            }
            ViewData["ApplicationTestId"] = new SelectList(_context.Set<application_test>(), "ApplicationTestId", "ApplicationTestId", answers.ApplicationTestId);
            return View(answers);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnswersId,Total_grades,Pass,Answer_details,ApplicationTestId")] Answers answers)
        {
            if (id != answers.AnswersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswersExists(answers.AnswersId))
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
            ViewData["ApplicationTestId"] = new SelectList(_context.Set<application_test>(), "ApplicationTestId", "ApplicationTestId", answers.ApplicationTestId);
            return View(answers);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Answers == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers
                .Include(a => a.ApplicationTest)
                .FirstOrDefaultAsync(m => m.AnswersId == id);
            if (answers == null)
            {
                return NotFound();
            }

            return View(answers);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Answers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Answers'  is null.");
            }
            var answers = await _context.Answers.FindAsync(id);
            if (answers != null)
            {
                _context.Answers.Remove(answers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswersExists(int id)
        {
          return _context.Answers.Any(e => e.AnswersId == id);
        }
    }
}
