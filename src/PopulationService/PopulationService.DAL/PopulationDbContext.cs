using Microsoft.EntityFrameworkCore;
using PopulationService.DAL.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopulationService.DAL

{
    public class PopulationDbContext : DbContext
    {
        public DbSet<PopulationInformation> PopulationInformations { get; set; }

        public PopulationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
