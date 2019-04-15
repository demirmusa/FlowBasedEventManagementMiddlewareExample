using AutoMapper;
using EFCore.GenericRepository;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystem.Business;
using StudentManagementSystem.Business.People.Dto;
using StudentManagementSystem.Business.Population.Dto;
using StudentManagementSystem.Data.DbEntities;
using AutoMapper.Mappers.Internal;
using StudentManagementSystem.Business.StudentBusiness;
using StudentManagementSystem.Business.UserBusiness.Dto;
using StudentManagementSystem.Business.StudentBusiness.Dto;

namespace StudentManagementSystem.WebUI
{
    public class ServicesInitializer
    {
        public static void InitializeServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddGenericRepositorySingleton();

            services.AddScoped(typeof(ISMSDbContextGenericRepository<>), typeof(SMSDbContextGenericRepository<>));

            services.AddTransient<Business.StudentSearch.interfaces.IStudentSearchService, Business.StudentSearch.StudentSearchService>();

            services.AddTransient<Business.UserBusiness.Interface.IUserService, Business.UserBusiness.UserService>();
            services.AddTransient<Business.People.Interfaces.IPeopleService, Business.People.PeopleService>();
            services.AddTransient<Business.Cipher.Interfaces.ICipherService, Business.Cipher.CipherService>();
            services.AddTransient<Business.Population.Interfaces.IPopulationService, Business.Population.PopulationService>();
            services.AddTransient<Business.StudentBusiness.Interfaces.IStudentRegistrationService, StudentRegistrationService>();

        }

      
    }
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NewStudentInformationDto, StudentInformation>()
            .ForMember(m => m.CreationTime, opt => opt.Ignore())
            .ForMember(m => m.Deleted, opt => opt.Ignore())
            .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
            .ForMember(m => m.User, opt => opt.Ignore())
            .ReverseMap();
            CreateMap<StudentInformationDto, StudentInformation>()
               .ForMember(m => m.CreationTime, opt => opt.Ignore())
               .ForMember(m => m.Deleted, opt => opt.Ignore())
               .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
               .ForMember(m => m.User, opt => opt.Ignore())
               .ReverseMap();
            CreateMap<PopulationInformationDto, PopulationInformation>()
            .ForMember(m => m.CreationTime, opt => opt.Ignore())
            .ForMember(m => m.Deleted, opt => opt.Ignore())
            .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<PersonDto, Person>(MemberList.Destination)
            .ForMember(m => m.CreationTime, opt => opt.Ignore())
            .ForMember(m => m.Deleted, opt => opt.Ignore())
            .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
            .ForMember(m => m.PopulationInformation, opt => opt.Ignore())
            .ReverseMap();

            //CreateMap<NewUserDto, User>(MemberList.Destination)
            //.ForMember(m => m.CreationTime, opt => opt.Ignore())
            //.ForMember(m => m.Deleted, opt => opt.Ignore())
            //.ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
            //.ForMember(m => m.PasswordHash, opt => opt.Ignore())
            //.ForMember(m => m.Person, opt => opt.Ignore())
            //.ReverseMap();

            CreateMap<UserDto, User>(MemberList.Destination)
          .ForMember(m => m.CreationTime, opt => opt.Ignore())
          .ForMember(m => m.Deleted, opt => opt.Ignore())
          .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
          .ForMember(m => m.PasswordHash, opt => opt.Ignore())
          .ForMember(m => m.Person, opt => opt.Ignore())
          .ReverseMap();
        }
    }
}
