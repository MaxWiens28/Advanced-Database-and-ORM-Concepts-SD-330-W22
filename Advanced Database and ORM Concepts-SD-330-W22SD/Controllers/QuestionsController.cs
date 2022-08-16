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
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<Question> questions = _context.Question.ToList();
            return View(questions);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question question = await _context.Question
                .Include(a => a.User)
                .FirstOrDefaultAsync(q => q.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Title, string Description)
        {
            Question newQuestion = new Question();
            newQuestion.Title = Title;
            newQuestion.Description = Description;
            _context.Question.Add(newQuestion);
            _context.SaveChanges();
            return View();
        }
    }
}
