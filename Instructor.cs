using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10_09
{
    internal class Instructor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname {  get; set; }

        public List<Course> Courses { get; set; } = new();


    }
}
