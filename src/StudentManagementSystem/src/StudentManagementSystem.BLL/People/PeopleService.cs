using AutoMapper;
using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.BLL.People.Dto;
using StudentManagementSystem.BLL.People.Interfaces;
using StudentManagementSystem.BLL.Population.Interfaces;
using StudentManagementSystem.DAL.DbEntities;
using System;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.People
{
    public class PeopleService : IPeopleService
    {
        readonly ISMSDbContextGenericRepository<Person> _personRepo;
        readonly IPopulationService _populationService;
        readonly IMapper _mapper;
        public PeopleService(ISMSDbContextGenericRepository<Person> personRepo, IPopulationService populationService, IMapper mapper)
        {
            _mapper = mapper;
            _personRepo = personRepo;
            _populationService = populationService;
        }
        public async Task<GenericResult<PersonDto>> AddPerson(PersonDto personDto)
        {
            try
            {
                if (personDto.FKPopulationInformationID.HasValue)
                {
                    var isPopulationExists = (await _populationService.IsPopulationExists(personDto.FKPopulationInformationID.Value));
                    if (!isPopulationExists.IsSucceed)
                        return GenericResult<PersonDto>.UserSafeError("An error occurred when requesting population.Errors: " + isPopulationExists.GetAllMessage());
                    else if (!isPopulationExists.Data)
                        return GenericResult<PersonDto>.UserSafeError("There is no population info with given id");
                }

                var newPerson = await _personRepo.InsertAsync(_mapper.Map<Person>(personDto));
                return GenericResult<PersonDto>.Success(_mapper.Map<PersonDto>(newPerson));
            }
            catch (Exception e)
            {
                return GenericResult<PersonDto>.Error(e);
            }
        }
        public async Task<bool> IsPersonExists(int id) =>
           await _personRepo.AsQueryable().AnyAsync(x => x.ID == id);



    }
}
