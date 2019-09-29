using ProjectManager.Entities;
using System.Data.Entity;

namespace ProjectManager.DataLayer
{
    public class ProjectManagerContext : DbContext
    {

        public ProjectManagerContext():base("name = projectmanagerdbconn")
        {

        }

        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ParentTask> ParentTask { get; set; }
    }
}
