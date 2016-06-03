using System.Collections.Generic;

namespace pre_interview_test.models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }

        public Employee()
        {
            Trainings = new List<Training>();
        }
    }
}
