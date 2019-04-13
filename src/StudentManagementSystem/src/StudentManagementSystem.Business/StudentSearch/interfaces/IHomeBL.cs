using Example.CoreShareds;
using StudentManagementSystem.Business.StudentSearch.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.StudentSearch.interfaces
{
    public interface IStudentSearchBL
    {
        Task<GenericResult<List<(int id, string name,string foto)>>> SearchStudent(string query);
        Task<GenericResult<StudentInformationDto>> GetStudentInformationById(int id);
    }
}
