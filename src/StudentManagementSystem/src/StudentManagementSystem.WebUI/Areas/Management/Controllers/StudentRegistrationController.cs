using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.CoreShareds;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.BLL.StudentBusiness.Dto;
using StudentManagementSystem.BLL.StudentBusiness.Interfaces;

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
        [HttpPost]
        public async Task<ActionResult> RegisterNewStudent(NewStudentInformationDto newStudentInformationDto)
        {
            var registrationResult = await _studentRegistrationService.AddNewStudent(newStudentInformationDto);
            var userSafe = registrationResult.GetUserSafeResult();

            return View("GenericResultView", userSafe.ConvertTo(userSafe.GetAllMessage()));
        }
    }
}