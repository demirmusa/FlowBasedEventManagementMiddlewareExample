﻿using EFCore.GenericRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementSystem.DAL.DbEntities
{
    public class Teacher : SoftDeletableDbEntity
    {
        public string CurrentTitle { get; set; }
        public int FKUserID { get; set; }

        [ForeignKey("FKUserID")]
        public virtual User User { get; set; }
    }
}
