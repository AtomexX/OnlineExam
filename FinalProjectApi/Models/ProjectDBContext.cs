using Microsoft.EntityFrameworkCore;
using FinalProjectApi.Models;

namespace FinalProjectApi.Models
{
    public partial class ProjectDBContext : DbContext
    {
        public ProjectDBContext()
        {

        }
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
        {
        }
        public virtual DbSet<TblUserDetails> TblUserDetails { get; set; }
        public DbSet<Subject> TblSubjects { get; set; }
        public DbSet<Question> TblQuestions { get; set; }
        public DbSet<QuestionSet> TblQuestionSets { get; set; }

        public virtual DbSet<TblReport> TblReport { get; set; }
    }
}