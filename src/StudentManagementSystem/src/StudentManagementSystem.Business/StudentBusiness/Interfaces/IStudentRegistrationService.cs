using Example.CoreShareds;
using StudentManagementSystem.Business.StudentBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.StudentBusiness.Interfaces
{
    public interface IStudentRegistrationService
    {
        Task<GenericResult<StudentInformationDto>> AddNewStudent(NewStudentInformationDto newStudentInformationDto);
    }
}
