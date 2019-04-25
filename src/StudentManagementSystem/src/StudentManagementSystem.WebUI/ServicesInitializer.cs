using AutoMapper;
using EFCore.GenericRepository;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystem.BLL;
using StudentManagementSystem.BLL.People.Dto;
using StudentManagementSystem.BLL.Population.Dto;
using StudentManagementSystem.DAL.DbEntities;
using AutoMapper.Mappers.Internal;
using StudentManagementSystem.BLL.UserBusiness.Dto;
using StudentManagementSystem.BLL.StudentBusiness.Dto;

namespace StudentManagementSystem.WebUI
{
    public class ServicesInitializer
    {
        public static void InitializeServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddGenericRepositoryScoped();

            services.AddScoped(typeof(ISMSDbContextGenericRepository<>), typeof(SMSDbContextGenericRepository<>));

            services.AddTransient<BLL.StudentSearch.interfaces.IStudentSearchService, BLL.StudentSearch.StudentSearchService>();

            services.AddTransient<BLL.UserBusiness.Interface.IUserService, BLL.UserBusiness.UserService>();

            services.AddTransient<BLL.People.Interfaces.IPeopleService, BLL.People.PeopleService>();

            services.AddTransient<BLL.Cipher.Interfaces.ICipherService, BLL.Cipher.CipherService>();

            services.AddTransient<BLL.Population.Interfaces.IPopulationService, BLL.Population.PopulationService>();

            services.AddTransient<BLL.StudentBusiness.Interfaces.IStudentRegistrationService, BLL.StudentBusiness.StudentRegistrationService>();

            services.AddTransient<BLL.Courses.Interfaces.ICourseScoreManagementService, BLL.Courses.CourseScoreManagementService>();

            services.AddTransient<BLL.Courses.Interfaces.ICourseManagementService, BLL.Courses.CourseManagementService>();
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

            CreateMap<PersonDto, Person>(MemberList.Destination)
            .ForMember(m => m.CreationTime, opt => opt.Ignore())
            .ForMember(m => m.Deleted, opt => opt.Ignore())
            .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
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
