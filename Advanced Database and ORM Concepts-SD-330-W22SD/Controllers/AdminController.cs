using Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Data;
using Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult AllQuestionsAndAnswers()
        {
            List<Question> questions = _context.Question.ToList();
            return View(questions);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Question == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Answer'  is null.");
            }
            Question question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
            }

            await _context.SaveChangesAsync();
            return View();
        }
    }
}
