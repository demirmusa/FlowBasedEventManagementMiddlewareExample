using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL.Courses.Dto
{
    public class CourseInformationDto
    {
        public int ID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int FKTeacherID { get; set; }
    }
}
