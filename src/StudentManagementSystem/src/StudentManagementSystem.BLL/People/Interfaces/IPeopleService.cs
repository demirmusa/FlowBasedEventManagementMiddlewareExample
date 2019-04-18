using Example.CoreShareds;
using StudentManagementSystem.BLL.People.Dto;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.People.Interfaces
{
    public interface IPeopleService
    {
        Task<GenericResult<PersonDto>> AddPerson(PersonDto personDto);
        Task<bool> IsPersonExists(int id);
    }
}
