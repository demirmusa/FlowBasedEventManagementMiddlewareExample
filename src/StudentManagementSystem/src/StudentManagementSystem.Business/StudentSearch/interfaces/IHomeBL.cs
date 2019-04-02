using Example.CoreShareds;
using StudentManagementSystem.Business.StudentSearch.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.StudentSearch.interfaces
{
    public interface IStudentSearchBL
    {
        Task<GenericResult<List<(int id, string name)>>> SearchStudent(string query);
        Task<GenericResult<StudentInformationDto>> GetStudentInformationById(int id);
    }
}
