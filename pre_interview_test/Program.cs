using pre_interview_test.DAL;
using pre_interview_test.models;
using System;

namespace pre_interview_test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context())
            {
                Console.WriteLine("Application is started");
                foreach (var item in db.Employees)
                {
                     Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
