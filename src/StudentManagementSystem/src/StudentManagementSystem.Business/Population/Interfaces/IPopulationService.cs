﻿using Example.CoreShareds;
using StudentManagementSystem.Business.Population.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.Population.Interfaces
{
    public interface IPopulationService
    {
        Task<GenericResult<int>> AddPopulationInfo(PopulationInformationDto informationDto);
        Task<GenericResult<bool>> IsPopulationExists(int id);
        Task<GenericResult<bool>> Delete(int id);
    }
}
