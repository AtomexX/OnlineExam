using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Models;

namespace FinalProjectApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchStudentsController : ControllerBase
  {
    private readonly ProjectDBContext _context;
    public SearchStudentsController(ProjectDBContext context)
    {
      _context = context;
    }

    //searching students
    [HttpGet]
    public IActionResult SearchStudents([FromQuery(Name ="subject")] string SubjectName, [FromQuery(Name ="state")] string State, [FromQuery(Name ="city")] string City, [FromQuery(Name ="level")] int level,[FromQuery(Name ="mark")] int Marks)
    {
      var query = (from user in _context.TblUserDetails
                   join report in _context.TblReport
                   on user.UserId equals report.UserId
                   join subject in _context.TblSubjects
                   on report.Subject_Id equals subject.Subject_Id
                   join ques in _context.TblQuestionSets
                   on subject.Subject_Id equals ques.SubjectRef_Id
                   where subject.Subject_Name == SubjectName && user.State == State && user.City == City && subject.Subject_Id == level && Marks >= report.Marks
                   select new { user.UserName, user.Email, user.MobileNumber, user.City, user.State }).ToList();

      if(query!=null)
      {
        return Ok(query);

      }
      else
      {
        return Ok("No data found for your search !");
      }
    }

  }
}
