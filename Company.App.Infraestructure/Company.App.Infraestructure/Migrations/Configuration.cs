namespace Company.App.Infraestructure.Migrations
{
    using Company.App.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal sealed class Configuration : DbMigrationsConfiguration<Company.App.Infraestructure.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Company.App.Infraestructure.AppContext";
        }

        protected override void Seed(Company.App.Infraestructure.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var courses = new List<Course>
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3,},
                new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
                new Course{CourseID=1045,Title="Calculus",Credits=4,},
                new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
                new Course{CourseID=2021,Title="Composition",Credits=3,},
                new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(s));
            context.SaveChanges();

            context.Students.AddOrUpdate(s => s.FirstMidName,
                new Student
                {
                    FirstMidName = "Gerard",
                    LastName = "Sans",
                    EnrollmentDate = DateTime.Now,
                    Email = "gerard.sans@gmail.com"                  
                },
                new Student { FirstMidName = "Gerard1", LastName = "Sans1", EnrollmentDate = DateTime.Now, Email = "gerard.sans1@gmail.com" }
            );

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050,},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F}
            };
            enrollments.ForEach(s => context.Enrollments.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
