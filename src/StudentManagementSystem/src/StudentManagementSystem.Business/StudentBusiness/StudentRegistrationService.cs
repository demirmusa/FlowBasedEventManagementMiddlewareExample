using AutoMapper;
using Example.CoreShareds;
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

namespace StudentManagementSystem.Business.StudentBusiness
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        IPeopleService _peopleService;
        IPopulationService _populationService;
        IUserService _userService;
        IMapper _mapper;
        ISMSDbContextGenericRepository<StudentInformation> _studentRepo;
        public StudentRegistrationService(
            IPeopleService peopleService,
            IPopulationService populationService,
            IUserService userService,
            IMapper mapper,
            ISMSDbContextGenericRepository<StudentInformation> studentRepo
            )
        {
            _peopleService = peopleService;
            _populationService = populationService;
            _userService = userService;
            _mapper = mapper;
            _studentRepo = studentRepo;
        }
        public async Task<GenericResult<StudentInformationDto>> AddNewStudent(NewStudentInformationDto newStudentInformationDto)
        {
            try
            {
                var newPopulationResult = await _populationService.AddPopulationInfo(newStudentInformationDto.NewUserDto.PersonDto.PopulationInformationDto);
                if (newPopulationResult.IsSucceed)
                {
                    newStudentInformationDto.NewUserDto.PersonDto.FKPopulationInformationID = newPopulationResult.Data.ID;
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

                            return GenericResult<StudentInformationDto>.Success(_mapper.Map<StudentInformationDto>(newStudent));
                        }
                        else
                            return newUserResult.ConvertTo(default(StudentInformationDto), "An error occurred while adding new user.");
                    }
                    else
                        return newPersonResult.ConvertTo(default(StudentInformationDto), "An error occurred while adding new person.");
                }
                else
                    return newPopulationResult.ConvertTo(default(StudentInformationDto), "An error occurred while adding new population.");
            }
            catch (Exception e)
            {
                return GenericResult<StudentInformationDto>.Error(e);
            }
        }
    }
}
