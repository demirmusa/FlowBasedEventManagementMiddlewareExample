﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PopulationService.DAL;

namespace PopulationService.DAL.Migrations
{
    [DbContext(typeof(PopulationDbContext))]
    partial class PopulationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PopulationService.DAL.DbEntities.PopulationInformation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("BirthPlace");

                    b.Property<DateTime>("CreationTime");

                    b.Property<bool>("Deleted");

                    b.Property<string>("FatherName");

                    b.Property<DateTime?>("LastUpdateTime");

                    b.Property<string>("MotherName");

                    b.Property<string>("Nationality");

                    b.HasKey("ID");

                    b.ToTable("PopulationInformations");
                });
#pragma warning restore 612, 618
        }
    }
}