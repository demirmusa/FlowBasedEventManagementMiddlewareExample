
using Example.EFCoreShared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementSystem.Data.dbEntities
{
    public class Person : SoftDeletableDbEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? FKPopulationInformationID { get; set; }

        [ForeignKey("FKPopulationInformationID")]
        public virtual PopulationInformation PopulationInformation { get; set; }
    }
}
