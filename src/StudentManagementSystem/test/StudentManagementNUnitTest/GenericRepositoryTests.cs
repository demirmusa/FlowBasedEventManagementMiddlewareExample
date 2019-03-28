using Example.EFCoreShared;
using Example.EFCoreShared.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using StudentManagementSystem.Business;
using StudentManagementSystem.Data;
using StudentManagementSystem.Data.dbEntities;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        IGenericRepository<SMSDbContext, Person> _personRepo;
        IGenericRepository<SMSDbContext, StudentCourseScore> _studentCourseScoreRepo;

        IMyGenericRepository<Person> _personMyRepo;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SMSDbContext>(options =>
                options.UseSqlServer("Data Source=LAPTOP-3O58F4FN;database=studentManagement_test;trusted_connection=yes;"));

            services.AddGenericRepositoryScoped();

            services.AddScoped(typeof(IMyGenericRepository<>), typeof(MyGenericRepository<>));

            var provider = services.BuildServiceProvider();

             _personRepo = provider.GetService<IGenericRepository<SMSDbContext, Person>>();
            _studentCourseScoreRepo = provider.GetService<IGenericRepository<SMSDbContext, StudentCourseScore>>();

            _personMyRepo = provider.GetService<IMyGenericRepository<Person>>();
        }

        [Test]
        public void PersonCreate()
        {
            try
            {
                _personRepo.Insert(new Person
                {
                    Name = "Musa",
                    Surname = "DEMÝR"
                });
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();

        }

        [Test]
        public void PersonUpdate()
        {
            try
            {
                var person = _personRepo.AsQueryable().FirstOrDefault();
                person.Name = person.Name + " " + DateTime.Now;
                _personRepo.Update(person);
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();
        }
        [Test]
        public void PersonDelete()
        {
            try
            {
                var person = _personRepo.AsQueryable().OrderByDescending(x => x.ID).FirstOrDefault();
                _personRepo.Delete(person.ID);
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();
        }
        [Test]
        public void PersonAddOrUpdate()
        {
            try
            {
                var person = _personRepo.AddOrUpdate(new Person
                {
                    Name = "Musa",
                    Surname = "DEMÝR " + DateTime.Now
                });

                person.Name = person.Name + " - " + DateTime.Now;
                _personRepo.AddOrUpdate(person);
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();
        }
        [Test]
        public void SoftUpdateableCreate()
        {
            try
            {
                var score = _studentCourseScoreRepo.Insert(new StudentCourseScore
                {
                    FKCourseID = 1,
                    FKStudentID = 2
                });
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();
        }
        [Test]
        public void SoftUpdateableUpdate()
        {
            try
            {
                var score = _studentCourseScoreRepo.AsQueryable().FirstOrDefault();

                score.FKStudentID = 456;
                _studentCourseScoreRepo.Update(score);
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();
        }
        [Test]
        public void SoftUpdateableAddOrUpdate()
        {
            try
            {
                var score = _studentCourseScoreRepo.AddOrUpdate(new StudentCourseScore
                {
                    FKCourseID = 5,
                    FKStudentID = 8
                });

                score.FKStudentID = 99;
                _studentCourseScoreRepo.AddOrUpdate(score);
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();
        }
        [Test]
        public void MyRepoTest()
        {
            try
            {
                var list = _personMyRepo.AsQueryable().ToList();
            }
            catch (Exception e)
            {
                Assert.That(false, "Error: " + e.Message);
            }
            Assert.Pass();
        }
    }
}