namespace HW_10_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbManager db = new DbManager();

            //db.EunsurePopulate();


            //1
            //db.GetStudentsByCourse(1);

            //2
            //db.GetCoursesByInstructorId(1);

            //3
            //db.GetCoursesByCount(5);

            //4
            //db.GetStudentsByAge(25);


            //5
            //db.GetAvgAge();


            //6
            //db.GetYoungest();


            //7
            db.GetCountCoursesByStudentId(1);


            //8
            db.GetAllStudents();

            //9
            db.GroupStudentsByAge();


            //10

            db.GetOrderStudents();

            //11

            db.GetSutdentsAndCourses();

            //12

            db.NoEnrollmentStudent();


            //13

            db.GetStudentByBothCourses(1, 2);


            //14

            db.StudentCountByCourse();

        }
    }
}
