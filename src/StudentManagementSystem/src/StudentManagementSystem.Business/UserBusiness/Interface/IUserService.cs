using Example.CoreShareds;
using StudentManagementSystem.Business.UserBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.UserBusiness.Interface
{
    public interface IUserService
    {
        Task<GenericResult<UserDto>> AddNewUser(NewUserDto newUserDto);
    }
}
