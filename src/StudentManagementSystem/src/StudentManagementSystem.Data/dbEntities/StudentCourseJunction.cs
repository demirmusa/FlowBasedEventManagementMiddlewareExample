using Example.EFCoreShared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementSystem.Data.dbEntities
{
    public class StudentCourseJunction : BaseDbEntity
    {
        public int FKStudentID { get; set; }
        public int FKCourseID { get; set; }
    }
}
