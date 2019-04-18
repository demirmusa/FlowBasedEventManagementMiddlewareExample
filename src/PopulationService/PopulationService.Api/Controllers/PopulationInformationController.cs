using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PopulationService.BLL;
using PopulationService.BLL.Dto;

namespace PopulationService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PopulationInformationController : ControllerBase
    {
        private readonly IPopulationService _populationService;

        public PopulationInformationController(IPopulationService populationService)
        {
            _populationService = populationService;
        }
        [HttpPost]
        public async Task<GenericResult<int>> AddNew(PopulationInformationDto dto)
        {
            var result = await _populationService.AddPopulationInfo(dto);
            return result.GetUserSafeResult();
        }
        [HttpDelete]
        public async Task<GenericResult<bool>> DeleteById(int id)
        {
            var result = await _populationService.Delete(id);
            return result.GetUserSafeResult();
        }
        [HttpGet("{id}")]
        public async Task<GenericResult<bool>> Exists(int id)
        {
            var result = await _populationService.IsPopulationExists(id);
            return result.GetUserSafeResult();
        }
    }
}