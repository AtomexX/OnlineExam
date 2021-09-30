using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProjectApi.Models
{
  public class TblReport
  {
    [Key]
    public int ReportID { get; set; }
    public int Marks { get; set; }

    [ForeignKey("TblUserDetails")]
    public int UserId { get; set; }

    [ForeignKey("TblQuestionSet")]
    public int QuestionSet_Id { get; set; }

    [ForeignKey("TblSubject")]
    public int Subject_Id { get; set; }

  }
}
