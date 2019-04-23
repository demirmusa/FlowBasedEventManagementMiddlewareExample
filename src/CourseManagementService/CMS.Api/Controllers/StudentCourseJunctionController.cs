using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BLL.StudentCourseJunctionBusiness;
using CMS.DAL.DbEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.GenericServiceControllers;
using CMS.DAL;
using CMS.BLL.CourseInformationBusiness.Dto;
using CMS.BLL.CourseInformationBusiness;
using Example.CoreShareds;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCourseJunctionController : BaseServiceController<StudentCourseJunctionService, CourseServiceDbContext, StudentCourseJunction>
    {
        public StudentCourseJunctionController(StudentCourseJunctionService service) : base(service)
        {
        }
        [HttpGet("{studentId}")]
        public async Task<GenericResult<List<CourseInformationDto>>> GetCoursesByStudentId(int studentId)
        {
            try
            {
                var result = await base._service.GetCoursesByStudentId(studentId);
                return GenericResult<List<CourseInformationDto>>.Success(result);
            }
            catch (Exception e)
            {
                return GenericResult<List<CourseInformationDto>>.UserSafeError("An error occurred");
            }
        }
    }
}