using PopulationService.DAL.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using EFCore.GenericRepository.interfaces;
using PopulationService.DAL;
using AutoMapper;
using PopulationService.BLL.Dto;
using Example.CoreShareds;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PopulationService.BLL
{
    public class PopulationService : IPopulationService
    {

        readonly IGenericRepository<PopulationDbContext, PopulationInformation> _populationRepo;
        private IMapper _mapper;
        public PopulationService(IGenericRepository<PopulationDbContext, PopulationInformation> populationRepo, IMapper mapper)
        {
            _populationRepo = populationRepo;
            _mapper = mapper;
        }
        public async Task<GenericResult<int>> AddPopulationInfo(PopulationInformationDto informationDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<PopulationInformation>(informationDto);
                var newPopulation = await _populationRepo.InsertAsync(mappedEntity);
                return GenericResult<int>.Success(newPopulation.ID);
            }
            catch (Exception e)
            {
                return GenericResult<int>.Error(e);
            }
        }

        public async Task<GenericResult<bool>> Delete(int id)
        {
            try
            {
                var newPopulation = await _populationRepo.DeleteAsync(id);
                return GenericResult<bool>.Success(true);
            }
            catch (Exception e)
            {
                return GenericResult<bool>.Error(e);
            }
        }

        public async Task<GenericResult<bool>> IsPopulationExists(int id)
        {
            try
            {
                bool exists = await _populationRepo.AsQueryable().AnyAsync(x => x.ID == id);
                return GenericResult<bool>.Success(exists);
            }
            catch (Exception e)
            {
                return GenericResult<bool>.Error(e);
            }
        }
    }
}
