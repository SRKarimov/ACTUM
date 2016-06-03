using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using pre_interview_test.models;

namespace pre_interview_test.DAL
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context ctx)
        {
            var trainings = new List<Training>();
            Training cs = new Training { Name = "C#", Description = "" };
            Training dotnet = new Training { Name = "ASP.NET", Description = "" };
            Training win10 = new Training { Name = "Windows 10", Description = "" };

            ctx.Trainings.Add(cs);
            ctx.Trainings.Add(dotnet);
            ctx.Trainings.Add(win10);

            ctx.SaveChanges();


            var employees = new List<Employee>
            {
                new Employee { Name = "Sergei", Surname = "Karimov", Trainings = new List<Training>() { cs, win10 } },
                new Employee { Name = "John", Surname = "Doe", Trainings = new List<Training>() { win10, dotnet } }
            };

            foreach(var item in employees)
            {
                ctx.Employees.Add(item);
            }
            ctx.SaveChanges();
        }
    }
}
