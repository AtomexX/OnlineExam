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
    public class ExamController : ControllerBase
    {
        ProjectDBContext _context;

        public ExamController(ProjectDBContext db)
        {
            _context = db;

        }
        [HttpGet("GetExamQuestion/{subject_name}/{level}")]
        
        public List<Question> GetExamQuestion(string subject_name, int level)
        {
            Subject subject = _context.TblSubjects.FirstOrDefault(s => s.Subject_Name == subject_name);
            
            QuestionSet questionSet = _context.TblQuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));

            return _context.TblQuestions.Where(q => q.QuestionSet == questionSet).ToList();
           //return _context.Questions.Select(q =>new UserModel { }).ToList();

        }
            [HttpPost]
        public IActionResult CalculateScore( int user_id,string subject_name,int level, string selectedAnswers )
        {
            int score = 0;
            Subject subject = _context.TblSubjects.FirstOrDefault(s => s.Subject_Name == subject_name);

            QuestionSet questionSet = _context.TblQuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));

            List<Question> questions =  _context.TblQuestions.Where(q => q.QuestionSet == questionSet).ToList();
           

            for(int i=0;i<selectedAnswers.Length;i++)
            {
                if (string.Compare(selectedAnswers[i].ToString(), questions[i].Correct_Option)==0)
                {
                    score++;
                }

                        
            }
            return Ok(score);
        }

    }
}
