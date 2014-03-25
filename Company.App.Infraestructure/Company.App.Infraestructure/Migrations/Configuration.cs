namespace Company.App.Infraestructure.Migrations
{
    using Company.App.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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

            context.Students.AddOrUpdate(s => s.FirstMidName,
                new Student { FirstMidName = "Gerard", LastName = "Sans", EnrollmentDate = DateTime.Now, Email = "gerard.sans@gmail.com" },
                new Student { FirstMidName = "Gerard1", LastName = "Sans1", EnrollmentDate = DateTime.Now, Email = "gerard.sans1@gmail.com" }
            );
        }
    }
}
