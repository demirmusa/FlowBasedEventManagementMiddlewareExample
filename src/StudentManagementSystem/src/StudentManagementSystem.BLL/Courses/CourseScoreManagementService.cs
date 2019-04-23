using Example.CoreShareds;
using Microsoft.Extensions.Options;
using StudentManagementSystem.BLL.Courses.Dto;
using StudentManagementSystem.BLL.Courses.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Courses
{
    public class CourseScoreManagementService : BaseHttpClientService, ICourseScoreManagementService
    {
        private readonly ServiceInformations _serviceInformations;

        public CourseScoreManagementService(
            IHttpClientFactory httpClientFactory,
            IOptions<ServiceInformations> serviceInformations
            ) : base(httpClientFactory)
        {
            this._serviceInformations = serviceInformations.Value ??
                throw new Exception("Error!.CourseManagementService information can not be null. Define service informations in appsettings.json");
        }
        public async Task<GenericResult<List<CourseInformationDto>>> GetCoursesByStudentId(int studentId) =>
          await Get<GenericResult<List<CourseInformationDto>>>(_serviceInformations.CourseManagementService.BaseUrl + "/api/StudentCourseJunction/GetCoursesByStudentId/" + studentId);


        public async Task<GenericResult<List<StudentCourseScoreListDto>>> GetScoresByCourseAndStudentId(int studentId, int courseId) =>
             await Get<GenericResult<List<StudentCourseScoreListDto>>>(_serviceInformations.CourseManagementService.BaseUrl + "/api/StudentCourseScore/Get/" + studentId + "/" + courseId);


        public async Task<GenericResult<StudentCourseScoreDto>> UpdateScore(StudentCourseScoreDto dto) =>
            await Put<GenericResult<StudentCourseScoreDto>, StudentCourseScoreDto>(_serviceInformations.CourseManagementService.BaseUrl + "/api/StudentCourseScore/Update", dto);

        public async Task<GenericResult<StudentCourseScoreDto>> InsertScore(StudentCourseScoreDto dto) =>
            await Post<GenericResult<StudentCourseScoreDto>, StudentCourseScoreDto>(_serviceInformations.CourseManagementService.BaseUrl + "/api/StudentCourseScore/Insert", dto);

    }
}
