using AutoMapper;
using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManagementSystem.BLL.Population.Dto;
using StudentManagementSystem.BLL.Population.Interfaces;
using StudentManagementSystem.DAL.DbEntities;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Population
{
    public class PopulationService : BaseHttpClientService, IPopulationService
    {
        private readonly ServiceInformations _serviceInformations;

        public PopulationService(
            IHttpClientFactory httpClientFactory,
            IOptions<ServiceInformations> serviceInformations
            ) : base(httpClientFactory)
        {
            this._serviceInformations = serviceInformations.Value ?? throw new Exception("Define service informations in appsettings.json");
        }
        public async Task<GenericResult<int>> AddPopulationInfo(PopulationInformationDto informationDto) =>
            await PostG<int, PopulationInformationDto>(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/AddNew", informationDto);

        public async Task<GenericResult<bool>> IsPopulationExists(int id) =>
          await GetG<bool>(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/Exists/" + id);

        public async Task<GenericResult<bool>> Delete(int id) =>
          await DeleteG<bool>(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/Delete/" + id);
    }
}
