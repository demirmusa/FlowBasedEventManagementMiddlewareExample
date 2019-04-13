using Example.CoreShareds;
using StudentManagementSystem.Business.Population.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.Population.Interfaces
{
    public interface IPopulationBL
    {
        Task<GenericResult<bool>> AddPopulationInfo(PopulationInformationDto informationDto);
        Task<bool> IsPopulationExists(int id);
    }
}
