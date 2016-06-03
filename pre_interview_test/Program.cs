using System;
using System.Data.SqlClient;
using System.Data;

using pre_interview_test.DAL;
using pre_interview_test.models;

namespace pre_interview_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Print("Application is started");

            ///Create context
            var ctx = new Context();

            ///create a repository to get employees
            IRepository<Employee> employeeRep = new BaseRepository<Employee>(ctx);

            ///create a repositories to get trainings
            IRepository<Training> trainingRep = new BaseRepository<Training>(ctx);

            ///Create a record of employee
            Employee empl_1 = new Employee();
            if (empl_1 != null)
            {
                empl_1.Id = 3;
                empl_1.Name = "Jane";
                empl_1.Surname = "Austin";
                employeeRep.Create(empl_1);
            }

            ///shoow all employees
            foreach (var employee in employeeRep.List())
            {
                Print(employee.Name);
            }

            Print("--------------");

            ///update a record of employee
            Employee empl_2 = new Employee();
            if (empl_2 != null)
            {
                empl_2 = employeeRep.Find(x => x.Name == "Sergei");
                if (empl_2 != null)
                {
                    empl_2.Name = "Vova";
                    employeeRep.Update(empl_2);
                }
            }

            ///shoow all employees
            foreach (var employee in employeeRep.List())
            {
                Print(employee.Name);
            }

            Print("--------------");

            ///show all employees with their trainings
            foreach (var employee in employeeRep.List())
            {
                Console.WriteLine(employee.Name);
                foreach (var training in employee.Trainings)
                {
                    Console.WriteLine(training.Name);
                }
            }

            Print("--------------");

            ///show a list of trainings with all employees who joined to the training
            foreach (var training in trainingRep.List())
            {
                Console.WriteLine(training.Name);
                foreach (var employee in training.Employees)
                {
                    Console.WriteLine(employee.Name);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void Print(string text)
        {
            Console.WriteLine("ACTUM: {0}", text);
        }

        /// <summary>
        /// Call the stored procedure Insert
        /// </summary>
        public void SP_Insert()
        {
            using (var ctx = new Context())
            {
                var result = ctx.Database.ExecuteSqlCommand("sp_CreateEmployee @Name, @Surname", new SqlParameter("@Name", "Jane"), new SqlParameter("@Surname", "Eyre"));
            }
        }

        /// <summary>
        /// Call the stored procedure Update
        /// </summary>
        public void SP_Update()
        {
            using (var ctx = new Context())
            {
                var parameter = new SqlParameter();
                parameter.ParameterName = "@Name";
                parameter.Direction = ParameterDirection.Output;
                parameter.SqlDbType = SqlDbType.Int;
                var employee = ctx.Database.ExecuteSqlCommand("sp_UpdateEmployee @Name, @Id OUT", new SqlParameter("@Name", "Vova"), parameter);
                Console.WriteLine(parameter.Value);
            }
        }
    }
}
