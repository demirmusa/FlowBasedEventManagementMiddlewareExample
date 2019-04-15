using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Business.StudentBusiness.Dto;
using StudentManagementSystem.Business.StudentBusiness.Interfaces;

namespace StudentManagementSystem.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    public class StudentRegistrationController : Controller
    {
        IStudentRegistrationService _studentRegistrationService;
        public StudentRegistrationController(IStudentRegistrationService studentRegistrationService)
        {
            _studentRegistrationService = studentRegistrationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<GenericResult<bool>> RegisterNewStudent(NewStudentInformationDto newStudentInformationDto)
        {
            var registrationResult = await _studentRegistrationService.AddNewStudent(newStudentInformationDto);
            return registrationResult.GetUserSafeResult<bool, StudentInformationDto>();
        }
    }
}