using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL.StudentSearch.Dto
{
    public class StudentSearchResultDto
    {
        public int ID { get; set; }

        public DateTime RegistrationDate { get; set; }
        public string StudentNumber { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
    }
}
