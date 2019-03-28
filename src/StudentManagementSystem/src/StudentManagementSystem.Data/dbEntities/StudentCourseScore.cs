﻿using Example.EFCoreShared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementSystem.Data.dbEntities
{
    public class StudentCourseScore : SoftUpdatableDbEntity
    {
        public int FKCourseID { get; set; }
        public int FKStudentID { get; set; }
        public double Score { get; set; }
    }
}
