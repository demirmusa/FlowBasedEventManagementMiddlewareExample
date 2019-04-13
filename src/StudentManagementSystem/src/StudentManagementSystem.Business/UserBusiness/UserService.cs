using AutoMapper;
using Example.CoreShareds;
using StudentManagementSystem.Business.Cipher.Interfaces;
using StudentManagementSystem.Business.People.Interfaces;
using StudentManagementSystem.Business.UserBusiness.Dto;
using StudentManagementSystem.Data.DbEntities;
using System;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business.UserBusiness
{
    /// <summary>
    /// work with service
    /// </summary>
    public class UserService
    {
        ISMSDbContextGenericRepository<User> _userRepo;
        IPeopleService _peopleService;
        ICipherService _cipherService;
        IMapper _mapper;
        public UserService(IPeopleService peopleService, ISMSDbContextGenericRepository<User> userRepo, ICipherService cipherService, IMapper mapper)
        {
            _peopleService = peopleService;
            _userRepo = userRepo;
            _cipherService = cipherService;
            _mapper = mapper;
        }
        public async Task<GenericResult<UserDto>> AddNewUser(NewUserDto newUserDto)
        {
            try
            {
                if (!await _peopleService.IsPersonExists(newUserDto.FKPersonID))
                    return GenericResult<UserDto>.UserSafeError("There is no person info with given id");


                var newUser = await _userRepo.InsertAsync(new User
                {
                    FKPersonID = newUserDto.FKPersonID,
                    Email = newUserDto.Email,
                    UserName = newUserDto.UserName,
                    PasswordHash = _cipherService.Encrypt(newUserDto.Password)
                });
                return GenericResult<UserDto>.Success(_mapper.Map<UserDto>(newUser));
            }
            catch (Exception e)
            {
                return GenericResult<UserDto>.Error(e);
            }
        }
    }
}
