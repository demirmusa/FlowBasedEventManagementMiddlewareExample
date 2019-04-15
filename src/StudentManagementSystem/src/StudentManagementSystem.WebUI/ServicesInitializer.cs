using AutoMapper;
using EFCore.GenericRepository;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystem.Business;
using StudentManagementSystem.Business.People.Dto;
using StudentManagementSystem.Business.Population.Dto;
using StudentManagementSystem.Data.DbEntities;
using AutoMapper.Mappers.Internal;
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
            services.AddTransient<Business.StudentBusiness.Interfaces.IStudentRegistrationService, Business.StudentBusiness.Interfaces.IStudentRegistrationService>();


        }

        public static void AutoMapperInitizer(IMapper mapper)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<PopulationInformation, PopulationInformationDto>();
                config.CreateMap<PopulationInformationDto, PopulationInformation>();

                config.CreateMap<Person, PersonDto>();
                config.CreateMap<PersonDto, Person>();


            });
        }
    }
}
