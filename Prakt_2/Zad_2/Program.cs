using System;

namespace Zad_2
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            GradeBook gradeBook = new GradeBook("DSTR1", "A.Dichev");
            
            Console.WriteLine(gradeBook.InstructorName);
            gradeBook.InstructorName = "I.Georgiev";

            Console.WriteLine(gradeBook.CourseStart);

            gradeBook.DisplayMessage();

            (int, string, string) tuple = gradeBook.GradeBookTitle();
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);
            Console.WriteLine(tuple.Item3);

            gradeBook.ChangeCourseTitle(("DIS", "V.Babev"));
            gradeBook.DisplayMessage();

            return 0;
        }
    }
}