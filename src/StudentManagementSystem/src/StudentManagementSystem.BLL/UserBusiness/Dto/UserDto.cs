using StudentManagementSystem.BLL.People.Dto;

namespace StudentManagementSystem.BLL.UserBusiness.Dto
{
    public class UserDto
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int FKPersonID { get; set; }
        public PersonDto PersonDto { get; set; }
    }
}
