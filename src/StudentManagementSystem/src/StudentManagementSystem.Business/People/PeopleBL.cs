using AutoMapper;
using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Business.People.Dto;
using StudentManagementSystem.Business.People.Interfaces;
using StudentManagementSystem.Business.Population.Interfaces;
using StudentManagementSystem.Data.DbEntities;
using System;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.People
{
    public class PeopleBL : IPeopleBL
    {
        ISMSDbContextGenericRepository<Person> _personRepo;
        IPopulationBL _populationBL;
        IMapper _mapper;
        public PeopleBL(ISMSDbContextGenericRepository<Person> personRepo, IPopulationBL populationBL, IMapper mapper)
        {
            _mapper = mapper;
            _personRepo = personRepo;
            _populationBL = populationBL;
        }
        public async Task<GenericResult<bool>> AddPerson(PersonDto personDto)
        {
            try
            {
                if (personDto.FKPopulationInformationID.HasValue && !await _populationBL.IsPopulationExists(personDto.FKPopulationInformationID.Value))
                    return GenericResult<bool>.UserSafeError("There is no population info with given id");

                await _personRepo.InsertAsync(_mapper.Map<Person>(personDto));
                return GenericResult<bool>.Success(true);
            }
            catch (Exception e)
            {
                return GenericResult<bool>.Error(e);
            }
        }
        public async Task<bool> IsPersonExists(int id) =>
           await _personRepo.AsQueryable().AnyAsync(x => x.ID == id);



    }
}
