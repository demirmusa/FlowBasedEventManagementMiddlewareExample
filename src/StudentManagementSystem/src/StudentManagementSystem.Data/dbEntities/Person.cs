
using EFCore.GenericRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementSystem.DAL.DbEntities
{
    public class Person : SoftDeletableDbEntity
    {
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? FKPopulationInformationID { get; set; }
    }
}
