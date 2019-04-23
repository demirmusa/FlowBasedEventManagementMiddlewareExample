using AutoMapper;
using PopulationService.BLL.Dto;
using PopulationService.DAL.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationService.Api
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PopulationInformationDto, PopulationInformation>()
            .ForMember(m => m.CreationTime, opt => opt.Ignore())
            .ForMember(m => m.Deleted, opt => opt.Ignore())
            .ForMember(m => m.LastUpdateTime, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}
