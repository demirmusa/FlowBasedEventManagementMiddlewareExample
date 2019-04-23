using EFCore.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DAL.DbEntities
{
    public class StudentCourseScore : SoftUpdatableDbEntity
    {
        public int FKCourseID { get; set; }
        public int FKStudentID { get; set; }
        public double Score { get; set; }
    }
}
