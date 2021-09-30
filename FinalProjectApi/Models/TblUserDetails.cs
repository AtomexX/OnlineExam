using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApi.Models
{
    public partial class TblUserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DOB { get; set; }
        public string Qualification { get; set; }
        public int YearOfCompletion { get; set; }
    }
}
