using StudentManagementSystem.Business.UserBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Business.StudentBusiness.Dto
{
    public class NewStudentInformationDto
    {
        public DateTime RegistrationDate { get; set; }
        public string StudentNumber { get; set; }
        public int FKUserID { get; set; }
        public NewUserDto NewUserDto { get; set; }
    }
}
