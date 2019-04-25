using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.Extensions.Options;
using StudentManagementSystem.BLL.Courses.Dto;
using StudentManagementSystem.BLL.Courses.Interfaces;

namespace StudentManagementSystem.BLL.Courses
{
    public class CourseManagementService : BaseHttpClientService, ICourseManagementService
    {
        private readonly ServiceInformations _serviceInformations;

        public CourseManagementService(IHttpClientFactory httpClientFactory, IOptions<ServiceInformations> serviceInformations) : base(httpClientFactory)
        {
            this._serviceInformations = serviceInformations.Value ??
                                        throw new Exception("Error!.CourseManagementService information can not be null. Define service informations in appsettings.json");
        }

        public async Task<GenericResult<List<CourseInformationDto>>> GetAllCourse() =>
            await GetG<List<CourseInformationDto>>(_serviceInformations.CourseManagementService.BaseUrl + "/api/CourseInformation/Get");

        public async Task<GenericResult<CourseInformationDto>> GetCourse(int id) =>
            await GetG<CourseInformationDto>(_serviceInformations.CourseManagementService.BaseUrl + "/api/CourseInformation/Get/" + id);

        public async Task<GenericResult<CourseInformationDto>> UpdateCourse(CourseInformationDto dto) =>
            await PutG<CourseInformationDto, CourseInformationDto>(_serviceInformations.CourseManagementService.BaseUrl + "/api/CourseInformation/Update", dto);

        public async Task<GenericResult<CourseInformationDto>> InsertCourse(CourseInformationDto dto) =>
            await PostG<CourseInformationDto, CourseInformationDto>(_serviceInformations.CourseManagementService.BaseUrl + "/api/CourseInformation/Insert", dto);

        public async Task<GenericResult<CourseInformationDto>> DeleteCourse(int id) =>
            await DeleteG<CourseInformationDto>(_serviceInformations.CourseManagementService.BaseUrl + "/api/CourseInformation/Delete/" + id);
    }
}
