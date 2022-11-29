using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_2
{
    public class GradeBook
    {
        private string courseName;
        // subtask a)
        private string instructorName;

        // subtask d)
        public GradeBook(string courseName, string instructorName)
        {
            CourseName = courseName;
            InstructorName = instructorName;
            CourseStart = DateTime.Now.Year;
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        // subtask c)
        public string InstructorName
        {
            get { return instructorName; } 
            set { instructorName = value; }
        }
        // subtask b)
        public int CourseStart
        {
            get; private set;
        }
        
        // subtask e)
        public void DisplayMessage()
        {
            Console.WriteLine($"Welcome to the grade book for {CourseName}!");
            Console.WriteLine($"This course is presented by: {InstructorName}!");
        }
        // subtask f)
        public (int, string, string) GradeBookTitle()
        {
            return (CourseStart, CourseName, InstructorName);
        }
        // subtask g)
        public void ChangeCourseTitle((string, string) courseInstructorNames)
        {
            (CourseName, InstructorName) = courseInstructorNames;
        }
    }
}