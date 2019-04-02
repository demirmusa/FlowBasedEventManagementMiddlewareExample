﻿using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Business.StudentSearch.dto;
using StudentManagementSystem.Business.StudentSearch.interfaces;
using StudentManagementSystem.Data.dbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.StudentSearch
{
    public class StudentSearchBL : IStudentSearchBL
    {
        IMyGenericRepository<StudentInformation> _studentInformationRepo;
        public StudentSearchBL(IMyGenericRepository<StudentInformation> studentInformationRepo)
        {
            _studentInformationRepo = studentInformationRepo;
        }
        public async Task<GenericResult<List<(int id, string name)>>> SearchStudent(string query)
        {
            try
            {
                var students = await _studentInformationRepo.AsQueryable()
                    .Where(x =>
                        x.StudentNumber.Contains(query) ||
                        x.User.UserName.Contains(query) ||
                        x.User.Person.Name.Contains(query) ||
                        x.User.Person.Surname.Contains(query)
                    )
                    .OrderByDescending(x => x.ID).ThenBy(x => x.StudentNumber)
                    .Take(10)
                    .Select(x => new { x.ID, Name = x.User.Person.Name + " " + x.User.Person.Surname })
                    .ToListAsync();

                return GenericResult<List<(int id, string name)>>.Success(students.Select(x => (x.ID, x.Name)).ToList());
            }
            catch (Exception e)
            {
                return GenericResult<List<(int id, string name)>>.Error(null, e);
            }
        }
        public async Task<GenericResult<StudentInformationDto>> GetStudentInformationById(int id)
        {
            try
            {
                var student = await _studentInformationRepo.AsQueryable().Where(x => x.ID == id).Select(x => new StudentInformationDto
                {
                    ID = x.ID,
                    StudentNumber = x.StudentNumber,

                    Email = x.User.Email,
                    UserName = x.User.UserName,

                    Name = x.User.Person.Name,
                    Surname = x.User.Person.Surname,
                    RegistrationDate = x.RegistrationDate
                }).FirstOrDefaultAsync();

                if (student == null)
                    return GenericResult<StudentInformationDto>.UserSafeError(null, "There is no student with given id");

                return GenericResult<StudentInformationDto>.Success(student);
            }
            catch (Exception e)
            {
                return GenericResult<StudentInformationDto>.Error(null, e);
            }

        }
    }
}
