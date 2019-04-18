using AutoMapper;
using EventManager.Core.Interfaces;
using Example.CoreShareds;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Business.People.Dto;
using StudentManagementSystem.Business.People.Interfaces;
using StudentManagementSystem.Business.Population.Interfaces;
using StudentManagementSystem.Business.StudentBusiness.Dto;
using StudentManagementSystem.Business.StudentBusiness.Interfaces;
using StudentManagementSystem.Business.UserBusiness.Dto;
using StudentManagementSystem.Business.UserBusiness.Interface;
using StudentManagementSystem.Data.DbEntities;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace StudentManagementSystem.Business.StudentBusiness
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        readonly IPeopleService _peopleService;
        readonly IPopulationService _populationService;
        readonly IUserService _userService;
        readonly IMapper _mapper;
        readonly ISMSDbContextGenericRepository<StudentInformation> _studentRepo;
        readonly IEMPublisher _eventPublisher;

        public StudentRegistrationService(
            IPeopleService peopleService,
            IPopulationService populationService,
            IUserService userService,
            IMapper mapper,
            ISMSDbContextGenericRepository<StudentInformation> studentRepo,
            IEMPublisher eventPublisher
            )
        {
            _peopleService = peopleService;
            _populationService = populationService;
            _userService = userService;
            _mapper = mapper;
            _studentRepo = studentRepo;
            _eventPublisher = eventPublisher;
        }
        public async Task<GenericResult<StudentInformationDto>> AddNewStudent(NewStudentInformationDto newStudentInformationDto)
        {
            if (string.IsNullOrEmpty(newStudentInformationDto.StudentNumber))
            {
                return GenericResult<StudentInformationDto>.UserSafeError($"Error! Student number can not be null");
            }
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (await _studentRepo.AsQueryable().AnyAsync(x => x.StudentNumber == newStudentInformationDto.StudentNumber))
                    {
                        transaction.Dispose();
                        return GenericResult<StudentInformationDto>.UserSafeError($"Error! Student number: \"{newStudentInformationDto.StudentNumber}\" is already in use");
                    }
                    newStudentInformationDto.RegistrationDate = DateTime.Now;
                    var newPopulationResult = await _populationService.AddPopulationInfo(newStudentInformationDto.NewUserDto.PersonDto.PopulationInformationDto);
                    if (newPopulationResult.IsSucceed)
                    {
                        newStudentInformationDto.NewUserDto.PersonDto.FKPopulationInformationID = newPopulationResult.Data;
                        var newPersonResult = await _peopleService.AddPerson(newStudentInformationDto.NewUserDto.PersonDto);
                        if (newPersonResult.IsSucceed)
                        {
                            newStudentInformationDto.NewUserDto.FKPersonID = newPersonResult.Data.ID;
                            var newUserResult = await _userService.AddNewUser(newStudentInformationDto.NewUserDto);
                            if (newUserResult.IsSucceed)
                            {
                                newStudentInformationDto.FKUserID = newUserResult.Data.ID;
                                var newStudentDbEntity = _mapper.Map<StudentInformation>(newStudentInformationDto);

                                var newStudent = await _studentRepo.InsertAsync(newStudentDbEntity);

                                await _eventPublisher.PublishAsync(new NewStudentCreatedEvent()
                                {
                                    FKUserID = newStudent.FKUserID,
                                    StudentNumber = newStudent.StudentNumber
                                });
                                transaction.Complete();
                                return GenericResult<StudentInformationDto>.Success(_mapper.Map<StudentInformationDto>(newStudent));
                            }
                            else
                            {
                                transaction.Dispose();
                                return newUserResult.ConvertTo(default(StudentInformationDto), "An error occurred while adding new user.");
                            }
                        }
                        else
                        {
                            await _populationService.Delete(newPopulationResult.Data);

                            transaction.Dispose();
                            return newPersonResult.ConvertTo(default(StudentInformationDto), "An error occurred while adding new person.");
                        }
                    }
                    else
                    {
                        transaction.Dispose();
                        return newPopulationResult.ConvertTo(default(StudentInformationDto), "An error occurred while adding new population.");
                    }
                }
                catch (Exception e)
                {
                    transaction.Dispose();
                    return GenericResult<StudentInformationDto>.Error(e);
                }
            }

        }
    }
}
