using Example.EFCoreShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Data.dbEntities
{
    public class PopulationInformation : SoftDeletableDbEntity
    {
        ///its string value just because this is an example project , we should storage countires and use country id in that
        public string Nationality { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }
    }
}
