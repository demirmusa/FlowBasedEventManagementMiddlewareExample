﻿using AutoMapper;
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
    public class PeopleService : IPeopleService
    {
        ISMSDbContextGenericRepository<Person> _personRepo;
        IPopulationService _populationService;
        IMapper _mapper;
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
                if (personDto.FKPopulationInformationID.HasValue && !await _populationService.IsPopulationExists(personDto.FKPopulationInformationID.Value))
                    return GenericResult<PersonDto>.UserSafeError("There is no population info with given id");

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