using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Company.App.Domain;
using System.Data.Entity;

namespace Company.App.Infraestructure
{
    public class StudentRepository : Repository<Student>, IRepository<Student>
    {
        public StudentRepository(DbContext dataContext) : base(dataContext) { }

    }
}
