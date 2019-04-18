using System;
using System.Collections.Generic;
using System.Text;

namespace PopulationService.BLL.Dto
{
    public class PopulationInformationDto
    {
        public int ID { get; set; }
        public string Nationality { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }
    }
}
