﻿using Example.EFCoreShared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementSystem.Data.dbEntities
{
    public class CourseInformation : SoftUpdatableDbEntity
    {
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int FKTeacherID { get; set; }

        [ForeignKey("FKTeacherID")]
        public virtual Teacher Teacher { get; set; }
    }
}
