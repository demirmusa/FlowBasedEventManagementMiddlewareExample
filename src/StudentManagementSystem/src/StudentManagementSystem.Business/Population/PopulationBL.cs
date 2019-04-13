using AutoMapper;
using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Business.Population.Dto;
using StudentManagementSystem.Data.DbEntities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.Population
{
    public class PopulationBL
    {
        ISMSDbContextGenericRepository<PopulationInformation> _populationRepo;
        private IMapper _mapper;
        public PopulationBL(ISMSDbContextGenericRepository<PopulationInformation> populationRepo, IMapper mapper)
        {
            _populationRepo = populationRepo;
            _mapper = mapper;
        }
        public async Task<GenericResult<bool>> AddPopulationInfo(PopulationInformationDto informationDto)
        {
            try
            {
                await _populationRepo.InsertAsync(_mapper.Map<PopulationInformation>(informationDto));
                return GenericResult<bool>.Success(true);
            }
            catch (Exception e)
            {
                return GenericResult<bool>.Error(e);

            }
        }
        public async Task<bool> IsPopulationExists(int id) =>
             await _populationRepo.AsQueryable().AnyAsync(x => x.ID == id);


    }
}
