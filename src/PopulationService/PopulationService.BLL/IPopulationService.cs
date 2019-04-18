using Example.CoreShareds;
using PopulationService.BLL.Dto;
using System.Threading.Tasks;

namespace PopulationService.BLL
{
    public interface IPopulationService
    {
        Task<GenericResult<int>> AddPopulationInfo(PopulationInformationDto informationDto);
        Task<GenericResult<bool>> IsPopulationExists(int id);
        Task<GenericResult<bool>> Delete(int id);

    }
}