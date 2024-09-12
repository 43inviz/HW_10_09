using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10_09
{
    internal class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BDDate {  get; set; }

        public List<Enrollment> Enrollments { get; set; } = new();



    }
}
