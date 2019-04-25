using Example.CoreShareds;
using StudentManagementSystem.BLL.Courses.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Courses.Interfaces
{
    public interface ICourseScoreManagementService
    {
        Task<GenericResult<List<CourseInformationDto>>> GetCoursesByStudentId(int studentId);
        Task<GenericResult<List<StudentCourseScoreListDto>>> GetScoresByCourseAndStudentId(int studentId, int courseId);
        Task<GenericResult<StudentCourseScoreDto>> InsertScore(StudentCourseScoreDto dto);
    }
}
