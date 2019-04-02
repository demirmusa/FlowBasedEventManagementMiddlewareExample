using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebUI.Models
{
    public class StudentInfoModel
    {
        public int ID { get; set; }

        public DateTime RegistrationDate { get; set; }
        public string StudentNumber { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
