using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Business.Population.Dto
{
    public class PopulationInformationDto
    {
        public string Nationality { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }
    }
}
