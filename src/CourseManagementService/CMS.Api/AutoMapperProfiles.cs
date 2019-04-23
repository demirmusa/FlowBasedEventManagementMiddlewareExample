using AutoMapper;
using CMS.BLL.CourseInformationBusiness.Dto;
using CMS.BLL.StudentCourseScoreBusiness.Dto;
using CMS.DAL.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Api
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CourseInformationDto, CourseInformation>()
                .ForMember(m => m.CreationTime, opt => opt.Ignore())
                .ForMember(m => m.Deleted, opt => opt.Ignore())
                .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<StudentCourseScoreDto, StudentCourseScore>()
                .ForMember(m => m.CreationTime, opt => opt.Ignore())
                .ForMember(m => m.Deleted, opt => opt.Ignore())
                .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
