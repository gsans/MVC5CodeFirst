using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;    

namespace Company.App.Domain
{
    public class Student
    {
        public int ID { get; set; }
        [DisplayName("Last Name"), StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [DisplayName("First and Middle Name"), StringLength(50, MinimumLength = 2)]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date), DisplayName("Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
