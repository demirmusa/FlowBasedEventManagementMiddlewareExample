using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Example.CoreShareds;
using StudentManagementSystem.BLL.Courses.Dto;

namespace StudentManagementSystem.BLL.Courses.Interfaces
{
    public interface ICourseManagementService
    {
        Task<GenericResult<List<CourseInformationDto>>> GetAllCourse();
        Task<GenericResult<CourseInformationDto>> GetCourse(int id);
        Task<GenericResult<CourseInformationDto>> UpdateCourse(CourseInformationDto dto);
        Task<GenericResult<CourseInformationDto>> InsertCourse(CourseInformationDto dto);
        Task<GenericResult<CourseInformationDto>> DeleteCourse(int id);
    }
}
