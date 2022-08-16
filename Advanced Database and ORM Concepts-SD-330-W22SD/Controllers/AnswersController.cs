using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Data;
using Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models;
using Microsoft.AspNetCore.Authorization;

namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Controllers
{
    [Authorize]
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Answer.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Answer == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Description)
        {
            Answer newAnswer = new Answer();
            newAnswer.Description = Description;
            _context.Answer.Add(newAnswer);
            _context.SaveChanges();
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Answer == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Answer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Answer'  is null.");
            }
            var answer = await _context.Answer.FindAsync(id);
            if (answer != null)
            {
                _context.Answer.Remove(answer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(int id)
        {
          return (_context.Answer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
