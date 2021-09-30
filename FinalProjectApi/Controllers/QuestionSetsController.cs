using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApi.Models
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionSetsController : ControllerBase
    {
        ProjectDBContext _context;

        public QuestionSetsController(ProjectDBContext db)
        {
            _context = db;


        }
        [HttpPost]
        public IActionResult AddQuestionSet(string subject_name,int level)
        {
            Subject subject = _context.TblSubjects.FirstOrDefault(s => s.Subject_Name == subject_name);
            if (subject == null)
            {
                return NotFound();
            }
            var question_set = new QuestionSet
            {
                Subject = subject,
                Level = level

            };
            using (var context = _context)
            {

                context.TblQuestionSets.Add(question_set);
                context.SaveChanges();
            }
            return Ok(subject);

        }
        [HttpDelete]
        public IActionResult DeleteQuestionSet(string subject_name, int level)
        {
            Subject subject = _context.TblSubjects.FirstOrDefault(s => s.Subject_Name == subject_name );
            if (subject == null)
            {
                return NotFound();
            }

            QuestionSet questionSet = _context.TblQuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));
            if (questionSet == null)
            {
                return NotFound();
            }

            _context.TblQuestionSets.Remove(questionSet);
            _context.SaveChanges();

            return Ok(subject);
        }
    }
}
