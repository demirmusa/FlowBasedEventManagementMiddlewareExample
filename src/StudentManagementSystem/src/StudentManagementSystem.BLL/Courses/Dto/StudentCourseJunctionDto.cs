using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL.Courses.Dto
{
    public class StudentCourseJunctionDto
    {
        public int ID { get; set; }
        public int FKStudentID { get; set; }
        public int FKCourseID { get; set; }
    }
}
