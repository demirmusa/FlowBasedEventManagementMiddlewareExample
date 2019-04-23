using EFCore.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DAL.DbEntities
{
    public class CourseInformation : SoftUpdatableDbEntity
    {
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int FKTeacherID { get; set; }
    }
}
