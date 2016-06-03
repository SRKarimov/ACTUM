using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using pre_interview_test.models;

namespace pre_interview_test.DAL
{
    public class Context : DbContext
    {
        public Context() : base ("ActumContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
