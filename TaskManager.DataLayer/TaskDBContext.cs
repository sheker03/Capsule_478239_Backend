using System.Data.Entity;
using TaskManager.Model;

namespace TaskManager.DataLayer
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext() : base("name=TaskManagerDbConnect")
        {

        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TaskDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
