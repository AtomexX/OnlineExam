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
    public class SubjectsController : ControllerBase
    {
        ProjectDBContext _context;

        public SubjectsController(ProjectDBContext db)
        {
            _context = db;


        }
        [HttpPost]
        public IActionResult AddSubject(string subject_name)
        {
            var subject = new Subject
            {
                Subject_Name = subject_name,

            };
            using (var context = _context)
            {

                context.TblSubjects.Add(subject);
                context.SaveChanges();
            }
            return Ok(subject);
        }

        [HttpDelete]
        public IActionResult DeleteSubject(string subject_name)
        {
        
            Subject subject = _context.TblSubjects.FirstOrDefault( s => s.Subject_Name==subject_name);
            if (subject == null)
            {
                return NotFound();
            }

            _context.TblSubjects.Remove(subject);
            _context.SaveChanges();

            return Ok(subject);
        }
    }
}
