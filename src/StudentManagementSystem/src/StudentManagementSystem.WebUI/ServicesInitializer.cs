using AutoMapper;
using EFCore.GenericRepository;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystem.Business;
using StudentManagementSystem.Business.People.Dto;
using StudentManagementSystem.Business.Population.Dto;
using StudentManagementSystem.Data.DbEntities;

namespace StudentManagementSystem.WebUI
{
    public class ServicesInitializer
    {
        public static void InitializeServices(IServiceCollection services)
        {
            services.AddGenericRepositorySingleton();

            services.AddScoped(typeof(ISMSDbContextGenericRepository<>), typeof(SMSDbContextGenericRepository<>));
            services.AddTransient<Business.StudentSearch.interfaces.IStudentSearchBL, Business.StudentSearch.StudentSearchBL>();
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
