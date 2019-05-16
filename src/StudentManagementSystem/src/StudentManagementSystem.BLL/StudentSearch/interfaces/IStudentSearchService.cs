using Example.CoreShareds;
using StudentManagementSystem.BLL.StudentSearch.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.StudentSearch.interfaces
{
    public interface IStudentSearchService
    {
        Task<GenericResult<List<(int id, string name,string foto, string studentNumber)>>> SearchStudent(string query);
        Task<GenericResult<StudentSearchResultDto>> GetStudentInformationById(int id);
        Task<GenericResult<List<(int id, string name, string foto, string studentNumber)>>> GetAllStudents();
    }
}
