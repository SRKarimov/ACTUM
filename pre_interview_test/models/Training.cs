using System.Collections.Generic;

namespace pre_interview_test.models
{
    public class Training
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public Training()
        {
            Employees = new List<Employee>();
        }
    }
}
