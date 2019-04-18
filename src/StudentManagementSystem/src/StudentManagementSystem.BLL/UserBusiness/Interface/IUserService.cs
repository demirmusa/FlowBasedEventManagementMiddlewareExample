using Example.CoreShareds;
using StudentManagementSystem.BLL.UserBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.UserBusiness.Interface
{
    public interface IUserService
    {
        Task<GenericResult<UserDto>> AddNewUser(NewUserDto newUserDto);
    }
}
