using CMS.DAL;
using EFCore.GenericRepository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CMS.DAL.DbEntities;
using System.Threading.Tasks;
using EFCore.GenericRepository.GenericServices;
using CMS.BLL.CourseInformationBusiness.Dto;
using AutoMapper;
using Example.CoreShareds;

namespace CMS.BLL.CourseInformationBusiness
{
    public class CourseInformationService : GenericAsyncService<CourseServiceDbContext, CourseInformation, CourseInformationDto>
    {
        public CourseInformationService(IGenericRepository<CourseServiceDbContext, CourseInformation> genericRepository, IMapper mapper)
            : base(genericRepository, mapper)
        {
        }    
    }
}
