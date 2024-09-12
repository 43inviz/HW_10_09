using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10_09
{
    internal class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }   

        public string Description { get; set; }


        public List<Enrollment> Enrollments { get; set; } = new();

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }




    }
}
