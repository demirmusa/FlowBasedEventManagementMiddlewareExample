using Example.CoreShareds;
using StudentManagementSystem.Business.People.Dto;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.People.Interfaces
{
    public interface IPeopleService
    {
        Task<GenericResult<PersonDto>> AddPerson(PersonDto personDto);
        Task<bool> IsPersonExists(int id);
    }
}
