using System.Data.Entity;

namespace JGB2ForumProject.DataModels
{
    public class JGB2ForumDBContext:DbContext
    {
        public JGB2ForumDBContext():base("name=JGB2ForumDBContext")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Vote> Votes { get; set; }

    }
}
