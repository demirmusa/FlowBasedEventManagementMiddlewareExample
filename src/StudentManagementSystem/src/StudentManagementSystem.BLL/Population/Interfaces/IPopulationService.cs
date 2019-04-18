using Example.CoreShareds;
using StudentManagementSystem.BLL.Population.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Population.Interfaces
{
    public interface IPopulationService
    {
        Task<GenericResult<int>> AddPopulationInfo(PopulationInformationDto informationDto);
        Task<GenericResult<bool>> IsPopulationExists(int id);
        Task<GenericResult<bool>> Delete(int id);
    }
}
