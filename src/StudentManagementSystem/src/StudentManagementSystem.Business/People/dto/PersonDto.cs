using StudentManagementSystem.BLL.Population.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL.People.Dto
{
    public class PersonDto
    {
        public int ID { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? FKPopulationInformationID { get; set; }
        public PopulationInformationDto PopulationInformationDto { get; set; }
    }
}
