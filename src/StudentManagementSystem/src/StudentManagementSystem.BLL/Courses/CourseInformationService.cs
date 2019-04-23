using Example.CoreShareds;
using Microsoft.Extensions.Options;
using StudentManagementSystem.BLL.Courses.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Courses
{
    public class CourseInformationService : BaseHttpClientService
    {
        private readonly ServiceInformations _serviceInformations;

        public CourseInformationService(
            IHttpClientFactory httpClientFactory,
            IOptions<ServiceInformations> serviceInformations
            ) : base(httpClientFactory)
        {

            if (serviceInformations.Value == null)
                throw new Exception("Define service informations in appsettings.json");

            this._serviceInformations = serviceInformations.Value;
        }
        public async Task<GenericResult<CourseInformationDto>> GetCoursesByStudentId(int studentId) =>
          await RequestGenericResultReturnsEndPointAsync<CourseInformationDto>(async (HttpClient client) =>
          {
              return await client.GetAsync(_serviceInformations.CourseManagementService.BaseUrl
                  + "/api/StudentCourseJunction/GetCoursesByStudentId/" + studentId);
          });

        public async Task<GenericResult<List<StudentCourseScoreListDto>>> GetScoresByCourseAndStudentId(int studentId, int courseId) =>
          await RequestGenericResultReturnsEndPointAsync<List<StudentCourseScoreListDto>>(async (HttpClient client) =>
          {
              return await client.GetAsync(_serviceInformations.CourseManagementService.BaseUrl
                  + "/api/StudentCourseScore/Get/" + studentId + "/" + courseId);
          });

        public async Task<GenericResult<StudentCourseScoreDto>> InsertUpdateScore


    }
}
