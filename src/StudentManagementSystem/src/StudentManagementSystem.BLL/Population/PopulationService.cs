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

            if (serviceInformations.Value == null)
                throw new Exception("Define service informations in appsettings.json");

            this._serviceInformations = serviceInformations.Value;
        }
        public async Task<GenericResult<int>> AddPopulationInfo(PopulationInformationDto informationDto) =>
            await RequestGenericResultReturnsEndPointAsync<int>(async (HttpClient client) =>
            {
                return await client.PostAsync(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/AddNew",
                                         new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(informationDto), System.Text.Encoding.UTF8, "application/json"));
            });


        public async Task<GenericResult<bool>> IsPopulationExists(int id) =>
            await RequestGenericResultReturnsEndPointAsync<bool>(async (HttpClient client) =>
            {
                return await client.GetAsync(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/Exists/" + id);
            });

        public async Task<GenericResult<bool>> Delete(int id) =>
            await RequestGenericResultReturnsEndPointAsync<bool>(async (HttpClient client) =>
             {
                 return await client.DeleteAsync(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/Delete/" + id);
             });
    }
}
