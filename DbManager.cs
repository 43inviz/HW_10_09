namespace HW_10_09
{
    internal class DbManager
    {
        public void EunsurePopulate()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();


                var instructors = new List<Instructor> {
                        new Instructor {Name = "Tom", Surname = "White"},
                        new Instructor {Name = "Tony", Surname = "Hard"}
                    };

                db.Instructors.AddRange(instructors);

                db.SaveChanges();

                var students = new List<Student>
                    {
                        new Student{ Name = "Max",Surname = "Black",BDDate = DateTime.Now},
                        new Student{Name = "Oleg",Surname = "Best",BDDate = DateTime.Now}
                    };

                db.Students.AddRange(students);
                db.SaveChanges();

                var courses = new List<Course> {
                    new Course { Name = "Course1",Description = "descr1",Instructor = instructors[0]},
                    new Course {Name = "Course2",Description = "decr2",Instructor = instructors[1]}
                };
                db.Courses.AddRange(courses);
                db.SaveChanges();

                var enrollments = new List<Enrollment>
                {
                    new Enrollment { Student = students[0], Course = courses[0], EnrollmentDate = DateTime.Now },
                    new Enrollment { Student = students[1],Course = courses[1],EnrollmentDate = DateTime.Now}
                };

                db.Enrollments.AddRange(enrollments);

                db.SaveChanges();
            }

        }


        public void GetStudentsByCourse(int courseId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var students = db.Enrollments.Where(e => e.CourseId == courseId).Select(e => e.Student).ToList();


            }
        }


        public void GetCoursesByInstructorId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                var courses = db.Courses.Where(c => c.InstructorId == id).ToList();
            }
        }

        public void GetCoursesByCount(int count)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Courses.Where(e => e.Enrollments.Count() > 5).ToList();
            }
        }

        public void GetStudentsByAge(int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var students = db.Students.Where(s => s.BDDate.Year - DateTime.Now.Year > age);
            }
        }



        public void GetAvgAge()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var age = db.Students.Average(s => s.BDDate.Year - DateTime.Now.Year);
            }
        }


        public void GetYoungest()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var student = db.Students.OrderBy(s => s.BDDate).FirstOrDefault();
            }
        }


        public void GetCountCoursesByStudentId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Enrollments.Where(e => e.StudentId == id).Count();
            }
        }

        public void GetAllStudents()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var students = db.Students.Distinct().ToList();
            }
        }


        public void GroupStudentsByAge()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var students = db.Students.GroupBy(s => s.BDDate.Year - DateTime.Now.Year).ToList();
            }
        }


        public void GetOrderStudents()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var students = db.Students.OrderBy(s => s.Name).ToList();
            }
        }


        public void GetSutdentsAndCourses()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var students = db.Students.Join(db.Enrollments,
                    stu => stu.Id,
                    en => en.StudentId,
                    (stu, en) => new
                    {
                        Student = stu,
                        Enrollment = en,
                    }).ToList();
            }
        }



        public void NoEnrollmentStudent()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Students.Where(s => s.Enrollments.Any(e => e.StudentId == s.Id && e.CourseId == 1)).ToList();
            }
        }


        public void GetStudentByBothCourses(int fstId,int secId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var students = db.Students.Where(s=>s.Enrollments.Any(e=>e.StudentId == s.Id && e.CourseId == fstId) &&
                    db.Enrollments.Any(e=>e.StudentId == s.Id && e.CourseId == secId));
            } 
        }

        public void StudentCountByCourse()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var count = db.Enrollments.GroupBy(e=>e.CourseId).
                    Select(g=>new { CourseId = g.Key,
                    StudentCount = g.Count()}).ToList();
            }
        }
    }
}
