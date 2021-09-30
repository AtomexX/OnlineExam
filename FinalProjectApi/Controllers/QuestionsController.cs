using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectApi.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        ProjectDBContext _context;

        public QuestionsController (ProjectDBContext db)
        {
            _context = db;


        }
        
        /*[HttpPost]
        public async Task<ActionResult<Question>>AddQuestion(Question question)
        {
            _context.TblQuestions.Add(question);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Question", question);
        }*/

        
        [HttpPost]
        
        public IActionResult AddQuestion(string question_description, string option1, string option2, string option3, string option4, string correct_option, string subject_name, int level)
        {
            Subject subject = _context.TblSubjects.FirstOrDefault(s => s.Subject_Name == subject_name);
            if (subject == null)
            {
                return NotFound();
            }

            QuestionSet questionSet = _context.TblQuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));
            if (questionSet == null)
            {
                return NotFound();
            }
            var question = new Question
            {
                Question_Desc = question_description,
                Option1 = option1,
                Option2 = option2,
                Option3 = option3,
                Option4 = option4,
                Correct_Option = correct_option,
                
                QuestionSet = questionSet
            };
            using (var context = _context)
            {

                context.TblQuestions.Add(question);
                context.SaveChanges();
            }
            return Ok(question);
        }
    }
}
