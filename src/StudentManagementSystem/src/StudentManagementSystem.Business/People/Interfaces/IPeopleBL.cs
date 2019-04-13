using Example.CoreShareds;
using StudentManagementSystem.Business.People.Dto;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.People.Interfaces
{
    public interface IPeopleBL
    {
        Task<GenericResult<bool>> AddPerson(PersonDto personDto);
        Task<bool> IsPersonExists(int id);
    }
}
