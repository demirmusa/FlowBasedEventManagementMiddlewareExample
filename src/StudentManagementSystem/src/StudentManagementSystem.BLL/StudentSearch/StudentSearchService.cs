using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.BLL.StudentSearch.Dto;
using StudentManagementSystem.BLL.StudentSearch.interfaces;
using StudentManagementSystem.DAL.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.StudentSearch
{
    public class StudentSearchService : IStudentSearchService
    {
        ISMSDbContextGenericRepository<StudentInformation> _studentInformationRepo;
        public StudentSearchService(ISMSDbContextGenericRepository<StudentInformation> studentInformationRepo)
        {
            _studentInformationRepo = studentInformationRepo;
        }
        public async Task<GenericResult<List<(int id, string name, string foto, string studentNumber)>>> SearchStudent(string query)
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
                    .Select(x => new { x.ID, Name = x.User.Person.Name + " " + x.User.Person.Surname, x.User.Person.PhotoUrl, x.StudentNumber })
                    .ToListAsync();

                return GenericResult<List<(int id, string name, string foto, string studentNumber)>>.Success(students.Select(x => (x.ID, x.Name, x.PhotoUrl, x.StudentNumber)).ToList());
            }
            catch (Exception e)
            {
                return GenericResult<List<(int id, string name, string foto, string studentNumber)>>.Error(null, e);
            }
        }
        public async Task<GenericResult<StudentSearchResultDto>> GetStudentInformationById(int id)
        {
            try
            {
                var student = await _studentInformationRepo.AsQueryable().Where(x => x.ID == id).Select(x => new StudentSearchResultDto
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
                    return GenericResult<StudentSearchResultDto>.UserSafeError(null, "There is no student with given id");

                return GenericResult<StudentSearchResultDto>.Success(student);
            }
            catch (Exception e)
            {
                return GenericResult<StudentSearchResultDto>.Error(null, e);
            }

        }
    }
}
