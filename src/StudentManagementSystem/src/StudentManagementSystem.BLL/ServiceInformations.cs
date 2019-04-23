using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL
{
    public class ServiceInformations
    {
        public ServiceInformation PopulationInformationService { get; set; }
        public ServiceInformation CourseManagementService { get; set; }
    }
    public class ServiceInformation
    {
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
