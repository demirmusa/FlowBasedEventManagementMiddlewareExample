using AutoMapper;
using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Business.Population.Dto;
using StudentManagementSystem.Business.Population.Interfaces;
using StudentManagementSystem.Data.DbEntities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.Population
{
    public class PopulationService : IPopulationService
    {
        ISMSDbContextGenericRepository<PopulationInformation> _populationRepo;
        private IMapper _mapper;
        public PopulationService(ISMSDbContextGenericRepository<PopulationInformation> populationRepo, IMapper mapper)
        {
            _populationRepo = populationRepo;
            _mapper = mapper;
        }
        public async Task<GenericResult<PopulationInformationDto>> AddPopulationInfo(PopulationInformationDto informationDto)
        {
            try
            {
                var newPopulation = await _populationRepo.InsertAsync(_mapper.Map<PopulationInformation>(informationDto));
                return GenericResult<PopulationInformationDto>.Success(_mapper.Map<PopulationInformationDto>(newPopulation));
            }
            catch (Exception e)
            {
                return GenericResult<PopulationInformationDto>.Error(e);
            }
        }
        public async Task<bool> IsPopulationExists(int id) =>
             await _populationRepo.AsQueryable().AnyAsync(x => x.ID == id);


    }
}
