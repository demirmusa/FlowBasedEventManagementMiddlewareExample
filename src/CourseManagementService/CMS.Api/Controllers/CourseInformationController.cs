using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BLL.CourseInformationBusiness;
using CMS.BLL.CourseInformationBusiness.Dto;
using CMS.DAL;
using CMS.DAL.DbEntities;
using Example.GenericServiceControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseInformationController : BaseServiceController<CourseInformationService, CourseServiceDbContext, CourseInformation, CourseInformationDto>
    {
        public CourseInformationController(CourseInformationService service) : base(service)
        {
        }
    }
}