using StudentManagementSystem.BLL.UserBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL.StudentBusiness.Dto
{
    public class StudentInformationDto
    {
        public DateTime RegistrationDate { get; set; }
        public string StudentNumber { get; set; }
        public int FKUserID { get; set; }
        public UserDto UserDto { get; set; }
    }
}
