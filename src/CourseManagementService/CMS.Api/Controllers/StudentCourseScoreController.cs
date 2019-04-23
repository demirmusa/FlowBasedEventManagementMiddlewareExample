using CMS.BLL.StudentCourseScoreBusiness;
using CMS.BLL.StudentCourseScoreBusiness.Dto;
using CMS.DAL;
using CMS.DAL.DbEntities;
using Example.CoreShareds;
using Example.GenericServiceControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCourseScoreController : BaseServiceController<StudentCourseScoreService, CourseServiceDbContext, StudentCourseScore, StudentCourseScoreDto>
    {
        public StudentCourseScoreController(StudentCourseScoreService service) : base(service)
        {
        }
        [HttpGet("{studentId}/{courseId}")]
        public async Task<ActionResult<GenericResult<List<StudentCourseScoreListDto>>>> Get(int studentId, int courseId)
        {
            try
            {
                var result = await base._service.Get(studentId, courseId);
                return GenericResult<List<StudentCourseScoreListDto>>.Success(result);
            }
            catch (Exception)
            {
                //TODO: log
                return GenericResult<List<StudentCourseScoreListDto>>.UserSafeError("An error occurred");
            }
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public override Task<ActionResult<GenericResult<StudentCourseScoreDto>>> Update(StudentCourseScoreDto entityDto)
        {
            throw new NotImplementedException("Update is not implemented. Use insert instead");
            //return base.Update(entityDto);
        }
    }
}