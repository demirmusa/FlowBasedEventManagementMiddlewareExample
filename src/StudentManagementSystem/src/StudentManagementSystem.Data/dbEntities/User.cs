using EFCore.GenericRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementSystem.Data.DbEntities
{
    public class User : SoftDeletableDbEntity
    {
        public int FKPersonID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        [ForeignKey("FKPersonID")]
        public virtual Person Person { get; set; }
    }
}
