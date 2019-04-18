using AutoMapper;
using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManagementSystem.Business.Population.Dto;
using StudentManagementSystem.Business.Population.Interfaces;
using StudentManagementSystem.Data.DbEntities;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.Population
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
                throw new Exception("Define service informations in appsetting.json");

            this._serviceInformations = serviceInformations.Value;
        }
        public async Task<GenericResult<int>> AddPopulationInfo(PopulationInformationDto informationDto) =>
            await RequestGenericResultReturnsEndPointAsync<int>((HttpClient client) =>
            {
                return client.PostAsync(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/AddNew",
                                         new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(informationDto)));
            });


        public async Task<GenericResult<bool>> IsPopulationExists(int id) =>
            await RequestGenericResultReturnsEndPointAsync<bool>((HttpClient client) =>
            {
                return client.GetAsync(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/Exists/" + id);
            });

        public async Task<GenericResult<bool>> Delete(int id) =>
            await RequestGenericResultReturnsEndPointAsync<bool>((HttpClient client) =>
             {
                 return client.DeleteAsync(_serviceInformations.PopulationInformationService.BaseUrl + "/api/PopulationInformation/Delete/" + id);
             });
    }
}
