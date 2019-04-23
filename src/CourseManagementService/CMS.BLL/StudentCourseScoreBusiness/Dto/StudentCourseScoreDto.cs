using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.BLL.StudentCourseScoreBusiness.Dto
{
    public class StudentCourseScoreDto
    {
        public int ID { get; set; }
        public int FKCourseID { get; set; }
        public int FKStudentID { get; set; }
        public double Score { get; set; }
    }
    public class StudentCourseScoreListDto
    {
        public int ID { get; set; }
        public double Score { get; set; }
        public bool Deleted { get; set; }
        public int? FKPreviousVersionID { get; set; }
    }
}
