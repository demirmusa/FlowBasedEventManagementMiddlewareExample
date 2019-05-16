using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PopulationService.Api.Controllers
{
    public class DoSomethingParameter
    {
        public int StudentCourseScoreId { get; set; }
        public int FKStudentId { get; set; }
        public int FKCourseId { get; set; }
        public double Score { get; set; }
    }
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public async Task<DoSomethingParameter> DoSomeThing(DoSomethingParameter param)
        {
            //do something
            return param;
        }
    }
}